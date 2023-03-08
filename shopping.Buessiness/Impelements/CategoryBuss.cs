using shopping.BussinessServiceContract.Services;
using Shopping.DataAcceServiesContract.Repositories;
using Framework.BaseModel;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping.Buessiness.Impelements
{
    public class CategoryBuss : ICategoryBuss
    {
        private readonly ICategoryRepository repo;
        public CategoryBuss(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public List<CategoryListItem> GetAllRoots()
        {
            return repo.GetAllRoots();
        }

        public Category GetCategory(int CategoryID)
        {
            return repo.Get(CategoryID);
        }

        public OperationResult RegisterCategory(CategoryAddModel cat)
        {
            if(repo.ExitsSlug(cat.Slug))
            {
                return new OperationResult("Registercategory", "Category").ToFail("Slug Alreay Exist ");
            }
            if (repo.ExitsSlug(cat.CategoryName))
            {
                return new OperationResult("Registercategory", "Category").ToFail("Category Name Alreay Exist ");
            }
            return repo.Add(cat);
        }

        public OperationResult RemoveCategory(int CategoryID)
        {
            if (repo.HasProduct(CategoryID))
            {
                return new OperationResult("Remove category", "Category").ToFail("This Category Has Related Product  ");
            }
            if (repo.HasChaid(CategoryID))
            {
                return new OperationResult("Remove category", "Category").ToFail("This Category Has Related Product ");
            }
            return repo.Remove(CategoryID);
        }

        public List<CategoryListItem> Search(CategorySearchModel sm, out int RecordCount)
        {
            if (sm.PageSize==0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult Update(CategoryUpdateModel cat)
        {
            if (repo.ExitsCategoryName(cat.CategoryName,cat.CategoryID))
            {
                return new OperationResult("Update category", "Category").ToFail("This Category Has been Assigned to Another Category  ");
            }
            if (repo.ExitsSlug(cat.Slug, cat.CategoryID))
            {
                return new OperationResult("Update category", "Category").ToFail("This Category Has been Assigned to Another Category  ");
            }
            return repo.Update(cat);

        }
    }
}
