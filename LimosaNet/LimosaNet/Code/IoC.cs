using FluentValidation;
using LN.Application.ServiceImplementation;
using LN.Application.Validation;
using LN.Contracts.Models;
using LN.Contracts.Service;
using LN.PosgreSQL;
using LN.PosgreSQL.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

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

            services.UseAuth(configuration);
        }


        private static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(assemblies));            
        }

        private static void UseAuth(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the ConfigurationBuilder instance of AuthSettings

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidIssuer = AuthOptions.ISSUER,

                ValidateAudience = false,
                ValidAudience = AuthOptions.AUDIENCE,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddTransient<TokenValidationParameters>(p => tokenValidationParameters);
           

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                // todo: get from IoC
                //var tokenValidationParameters = services.BuildServiceProvider().GetService<TokenValidationParameters>();
                options.TokenValidationParameters = tokenValidationParameters;
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                   
                };
            });
                    
        }
    }
}
