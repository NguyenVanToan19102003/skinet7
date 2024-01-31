
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        
        public StoreContext(DbContextOptions options ) : base(options){

        }

        public DbSet<Product> products {get ; set; }
        public DbSet<ProductType> producttypes { get; set; }
        public DbSet<ProductBrand> productbrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}