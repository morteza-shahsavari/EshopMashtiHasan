using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models.Cofigurations
{
    public class ProjectAreaConfigurations : IEntityTypeConfiguration<ProjectArea>
    {
        public void Configure(EntityTypeBuilder<ProjectArea> builder)
        {
            builder.HasKey(x => x.ProjectAreaID);
            builder.Property(x=>x.AreaName).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.PersianTitle).HasMaxLength(200).IsRequired(false);
            builder.HasMany(x=>x.ProjctControllers).WithOne(x=>x.ProjectArea)
                .HasForeignKey(x=>x.ProjectAreaID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
