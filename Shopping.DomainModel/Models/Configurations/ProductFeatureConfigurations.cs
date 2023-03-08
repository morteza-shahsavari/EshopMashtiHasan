using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Models.Configurations
{
    internal class ProductFeatureConfigurations:IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {

            builder.HasKey(x => x.ProductFeatureID);
            builder.Property(x => x.ProductFeatureValue).HasMaxLength(100).IsRequired();
        }
    }
}
