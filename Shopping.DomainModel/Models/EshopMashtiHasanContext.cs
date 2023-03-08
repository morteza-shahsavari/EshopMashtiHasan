using Microsoft.EntityFrameworkCore;

namespace Shopping.DomainModel.Models
{
    public class EshopMashtiHasanContext: DbContext
    {
        public EshopMashtiHasanContext(DbContextOptions<EshopMashtiHasanContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryFeature> CategoryFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<RelatedProduct> RelatedProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Supplier>(new Configurations.SupplierConfigurations());
            modelBuilder.ApplyConfiguration<Category>(new Configurations.CategoryConfigurations());
            modelBuilder.ApplyConfiguration<CategoryFeature>(new Configurations.CategoryFeatureConfigurations());
            modelBuilder.ApplyConfiguration<Feature>(new Configurations.FeatureConfigoration());
            modelBuilder.ApplyConfiguration<Order>(new Configurations.OrderConfigurations());
           modelBuilder.ApplyConfiguration<OrderDetails>(new Configurations.OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration<Product>(new Configurations.ProductConfiguration());
          modelBuilder.ApplyConfiguration<ProductFeature>(new Configurations.ProductFeatureConfigurations());
            modelBuilder.ApplyConfiguration<RelatedProduct>(new Configurations.RelatedProductConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
