using Microsoft.EntityFrameworkCore;
using eCommerceProject.Models;

namespace eCommerceProject.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Company> Companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=KAShop;" +
                    "Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                    new Category { Id=1, Name="Mobiles" },
                    new Category { Id=2, Name="Kitchen Accessories" },
                    new Category { Id=3, Name="Toys" },
                    new Category{Id=4, Name="Home & Living" }
                );

        }
    }
}
