using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Security.Domain.Models.Cofigurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.RoleID);
            builder.Property(x=>x.RoleName).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.RoleActions).WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Users).WithOne(x=>x.Role)
                .HasForeignKey(x=>x.RoleID).OnDelete(DeleteBehavior.NoAction) ;
        }
    }
}
