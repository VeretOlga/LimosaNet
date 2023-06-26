using LN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LN.PosgreSQL
{
    public class LimosaNetDbContext:DbContext
    {
        // private readonly IConfiguration _config;

        /// <summary>
        /// The database scheme
        /// </summary>
        protected internal const string DbScheme = "public";


        public LimosaNetDbContext(DbContextOptions<LimosaNetDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users { get; set; }

    }
}
