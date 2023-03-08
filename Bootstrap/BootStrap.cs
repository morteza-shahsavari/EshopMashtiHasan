using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shopping.Buessiness.Impelements;
using shopping.BussinessServiceContract.Services;
using Shopping.BussinessServiceContract.Services;
using Shopping.DataAcceServiesContract.Repositories;
using Shopping.DataAccess.Repositories;
using Shopping.DomainModel.Models;

namespace Shopping.Bootstrap
{
    public static class BootStrap
    {
        public static void WireUP(IServiceCollection services,string ConnectionString)
        {
            services.AddDbContext<EshopMashtiHasanContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(ConnectionString);
            }, ServiceLifetime.Scoped);
            services.AddScoped<ISupplierBuss, SupplierBuss>();
            services.AddScoped<ICategoryBuss,CategoryBuss >();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
