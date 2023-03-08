using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Models.Configurations
{
    internal class RelatedProductConfigurations : IEntityTypeConfiguration<RelatedProduct>
    {
        public void Configure(EntityTypeBuilder<RelatedProduct> builder)
        {
            builder.HasKey(x => x.RelatedProductID);
            builder.HasIndex(x => new { x.ProductID, x.RelatedID });

           builder.HasOne(x => x.Product).WithMany(x => x.Products).HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Related).WithMany(x => x.Relateds).HasForeignKey(x => x.RelatedID).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

