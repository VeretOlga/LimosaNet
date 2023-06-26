using FluentValidation;
using LN.Application.ServiceImplementation;
using LN.Application.Validation;
using LN.Contracts.Models;
using LN.Contracts.Service;
using LN.PosgreSQL;
using LN.PosgreSQL.Providers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LimosaNet.Code
{
    public static class IoC
    {


        private static Assembly[] assemblies = new[] { typeof(ValidationPreProcessor<>).Assembly, typeof(BaseProvider).Assembly};
        public static void ConfigureAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureMediatR();

            services.Scan(scan => scan
              .FromAssemblies(assemblies)
              .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
              .AsSelfWithInterfaces()
              .WithTransientLifetime());


            services.Scan(scan => scan.
            FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(BaseProvider)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());


            services.AddScoped<IAuthService, AuthService>();
            services.AddAutoMapper(typeof(UserCreateDto).Assembly);
           

            services.AddDbContext<LimosaNetDbContext>(options =>
            {
                var connString = configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql(connString);                
            });
        }


        private static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(assemblies));            
        }

        
    }
}
