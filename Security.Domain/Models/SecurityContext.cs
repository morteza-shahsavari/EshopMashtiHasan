using Microsoft.EntityFrameworkCore;
using Security.Domain.Models.Cofigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<ProjectAction> ProjectActions { get; set; }
        public DbSet<ProjectController> ProjectControllers { get; set; }
        public DbSet<ProjectArea> ProjectAreas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Role>(new Security.Domain.Models.Cofigurations.RoleConfigurations());
            modelBuilder.ApplyConfiguration<User>(new UserConfigurations());
            modelBuilder.ApplyConfiguration<RoleAction>(new RoleActionConfigurations());
            modelBuilder.ApplyConfiguration<ProjectAction>(new ProjectActionConfigurations());
            modelBuilder.ApplyConfiguration<ProjectArea>(new ProjectAreaConfigurations());
            modelBuilder.ApplyConfiguration<ProjectController>(new ProjectControllerConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
