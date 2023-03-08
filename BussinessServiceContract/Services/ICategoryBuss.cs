using Framework.BaseModel;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping.BussinessServiceContract.Services
{
    public interface ICategoryBuss
    {
        OperationResult RegisterCategory(CategoryAddModel cat);
        OperationResult RemoveCategory(int CategoryID);
        OperationResult Update(CategoryUpdateModel cat);
        List<CategoryListItem> GetAllRoots();
       List<CategoryListItem> Search(CategorySearchModel sm, out int RecordCount);
        Category GetCategory(int CategoryID);
    }
}
