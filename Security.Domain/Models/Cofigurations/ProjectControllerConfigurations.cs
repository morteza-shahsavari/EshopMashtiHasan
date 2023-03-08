using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models.Cofigurations
{
    public class ProjectControllerConfigurations : IEntityTypeConfiguration<ProjectController>
    {
        public void Configure(EntityTypeBuilder<ProjectController> builder)
        {
            builder.HasKey(x=>x.ProjectControllerID);
            builder.Property(x=>x.ProjectControllerName).IsRequired().HasMaxLength(128);
            builder.Property(x=>x.PersianTitle).IsRequired().HasMaxLength(200).IsRequired(false);
            builder.HasMany(x => x.ProjectActions).WithOne(x => x.ProjectController)
                .HasForeignKey(x =>x.ProjectControllerID ).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
