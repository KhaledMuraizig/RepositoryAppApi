using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RepositoryApp_Api_.Data
{
    public class Context : IdentityDbContext<User>
    {
        private readonly IConfiguration configuration;

        public Context(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("RepositoryConnection"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasIndex(i => i.Name).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
