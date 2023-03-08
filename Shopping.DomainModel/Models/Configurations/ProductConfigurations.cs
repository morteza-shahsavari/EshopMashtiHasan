using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>

    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductID);
            builder.Property(x => x.ProductName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(4000);
            //builder.HasMany(x => x.Products).WithOne(x => x.Product)
            //    .HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.ClientCascade);

            //builder.HasMany(x => x.Relateds).WithOne(x => x.Product)
            //    .HasForeignKey(x => x.RelatedID).OnDelete(DeleteBehavior.ClientCascade);



            //builder.HasMany(x => x.RelatedProducts)
            //    .WithOne(x => x.Product)
            //    .HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.NoAction);



            builder.HasMany(x => x.ProductFeatures).WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
