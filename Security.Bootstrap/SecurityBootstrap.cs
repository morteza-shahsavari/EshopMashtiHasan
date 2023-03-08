using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Security.Buessiness.Impelements;
using Security.BussinessServiceContract.Services;
using Security.DataAcceServiesContract.Repositories;
using Security.DataAccess.Repositories;

namespace Security.Bootstrap
{
    public class SecurityBootstrap
    {
        public static void WireUp(IServiceCollection services,string SecurityConnectionString)
        {
            services.AddDbContext<Security.Domain.Models.SecurityContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(SecurityConnectionString);
            }, ServiceLifetime.Scoped);
            services.AddScoped<IUserBuss,UserBuss>();
            services.AddScoped<IRoleBuss, RoleBuss>();
            services.AddScoped<IRoleActionBuss, RoleActionBuss>();
            services.AddScoped<IProjectActionBuss, ProjectActionBuss>();
            services.AddScoped<IProjectControllerBuss, ProjectControllerBuss>();
            services.AddScoped<IProjectAreaBuss, ProjectAreaBuss>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleActionRepository, RoleActionRepository>();
            services.AddScoped<IProjectAreaRepository, ProjectAreaRepository>();
            services.AddScoped<IProjectControllerRepository, ProjectControllerRepository>();
            services.AddScoped<IProjectActionRepository, ProjectActionRepository>();
            services.AddScoped<Security.DataAcceServiesContract.Repositories.IAcountRepository, Security.DataAccess.Repositories.AccountRepository>();
            services.AddScoped<Security.BussinessServiceContract.Services.IAccountBuss, Security.Bussiness.Implementations.AccountBuss>();
            services.AddScoped<Security.BussinessServiceContract.Services.IAuthHelper, Security.Bussiness.Implementations.AuthHelper>();
            services.AddScoped<Framework.Services.IPasswordHasher, Framework.PasswordHasher>();
        }
    }
}