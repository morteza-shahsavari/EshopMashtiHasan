using shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.BaseModel;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Bussiness.Implementations
{
    public class CategoryBuss : ICategoryBuss
    {
   

        public OperationResult RegisterCategory(CategoryAddModel cat)
        {
            throw new NotImplementedException();
        }

        public OperationResult RemoveCategory(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public List<CategoryListItem> Search(CategorySearchModel sm, out int RecordID)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(CategoryUpdateModel cat)
        {
            throw new NotImplementedException();
        }
        public Category GetCategory(int CategoryID)
        {
            throw new NotImplementedException();
        }
    }
}

