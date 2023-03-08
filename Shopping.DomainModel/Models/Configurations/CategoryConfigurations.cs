using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Models.Configurations
{
   public class CategoryConfigurations:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryID);

            builder.Property(x => x.CategoryName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ParentID).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(4000);
            builder.Property(x => x.Slug).HasMaxLength(1000);
            builder.Property(x => x.MenuIcon).HasMaxLength(1000);
            //builder.HasMany(x => x.Children).WithOne(x => x.Parent).HasForeignKey(x => x.ParentID)
            //    .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasMany(x => x.CategoryFeatures).WithOne(x => x.Category).HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
