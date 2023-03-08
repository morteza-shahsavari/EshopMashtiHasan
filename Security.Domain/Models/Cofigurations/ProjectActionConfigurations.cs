using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models.Cofigurations
{
    public class ProjectActionConfigurations : IEntityTypeConfiguration<ProjectAction>
    {
        public void Configure(EntityTypeBuilder<ProjectAction> builder)
        {
            builder.HasKey(x => x.ProjectActionID);
            builder.HasMany(x=>x.RoleActions).WithOne(x=>x.ProjectAction)
                .HasForeignKey(x=>x.ProjectActionID).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.ProjectActionName).HasMaxLength(100);
            builder.Property(x=>x.PersianTitle).HasMaxLength(200).IsRequired(false);
        }
    }
}
