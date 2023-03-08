using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Base;

namespace Shopping.DataAcceServiesContract.Repositories
{
    public interface ICategoryRepository : IBaseRepositorysearchable<Category, int, CategorySearchModel, CategoryListItem,CategoryUpdateModel,CategoryAddModel>
    {
        int GetChildCount(int categoryID);
        bool IsRoot(int categoryID);
        int GetProductCount(int categoryID);
        bool HasProduct(int categoryID);
        bool ExitsCategoryName(string categoryName);
        bool ExitsCategoryName(string categoryName,int CategoryID);
        bool ExitsSlug(string slug);
        bool ExitsSlug(string slug, int CategoryID);
        bool HasChaid(int CategoryID);
        List<CategoryListItem> GetAllRoots();
        Category Get(int categoryID);
    }
}
