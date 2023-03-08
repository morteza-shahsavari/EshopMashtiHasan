using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.BaseModel;
using Shopping.DataAcceServiesContract.Repositories;

using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;

namespace Shopping.DataAccess.Repositories
{
    public class CategoryRepository:ICategoryRepository


    {

        private CategoryListItem ToListItem(Category Cat)
        {
            var LstItem = new CategoryListItem
            {
                CategoryName = Cat.CategoryName,
                CategoryID = Cat.CategoryID,
                ProductCount = Cat.Products.Any() ? Cat.Children.Count() : 0,
                HasChild= Cat.Children.Any() 

            };
            return LstItem;
        }
        private readonly EshopMashtiHasanContext db;

        public CategoryRepository(EshopMashtiHasanContext db)
        {
            this.db = db;
        }
        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryID == id);
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete", "Category", id);
            try
            {
                var cat= db.Categories.FirstOrDefault(x => x.CategoryID == id);
                db.Categories.Remove(cat);
                db.SaveChanges();
                op.ToSuccess(id, "Delete Success");
            }
            catch (Exception ex)
            {

                op.ToFail(id, "Delete Fail" + ex.Message);
            }
            return op;
        }

        public OperationResult Update(CategoryUpdateModel model)
        {

            OperationResult op = new OperationResult("Update", "Category", model.CategoryID);
            try
            {
                var cat = db.Categories.FirstOrDefault(x => x.CategoryID == model.CategoryID);
                cat.CategoryName=model.CategoryName;
                cat.Slug=model.Slug;
                cat.Description=model.Description;
                cat.MenuIcon=model.MenuIcon;
                db.SaveChanges();
                op.ToSuccess("Update SuccessFullty");
            }
            catch (Exception ex)
            {
                op.ToFail("Update Failed" + ex.Message);
            }
            return op;
        }

        public OperationResult Add(CategoryAddModel model)
        {
            var op = new OperationResult("Add", "Category");
            try
            {
                Category c = new Category
                {
                    CategoryName = model.CategoryName,
                    Description = model.Description,
                    MenuIcon = model.MenuIcon,
                    ParentID = model.ParentID,
                    Slug = model.Slug,
                };
                if (model.ParentID==-1)
                {
                    c.ParentID = null;
                }
                db.Categories.Add(c);
                db.SaveChanges();
               // op.RecordID = c.CategoryID;
                op.ToSuccess(c.CategoryID, "Add Category SuccessFuly");
            }

            catch (Exception ex)
            {

                op.ToFail("Add Category Failed " + ex.Message);
            }
            return op;
        }

        public List<CategoryListItem> Search(CategorySearchModel sm, out int RecordCount)
        {
            var q = from item in db.Categories select item;

            if (sm.ParentID!=null)
            {
                q=q.Where(x=>x.ParentID==sm.ParentID);
            }
            if (!string.IsNullOrEmpty(sm.CategoryName))
            { 
            q=q.Where(x=>x.CategoryName.StartsWith(sm.CategoryName));
            }
            RecordCount= q.Count();
            return q.Select(x=> new CategoryListItem
            {
                CategoryName = x.CategoryName,
                CategoryID = x.CategoryID,
                ProductCount = x.Products.Any() ? x.Children.Count() : 0,
                HasChild = x.Children.Any()
            }).Skip(sm.PageIndex*sm.PageSize).Take(sm.PageSize).ToList();
        }

        public int GetChildCount(int categoryID)
        {
            return db.Categories.Count(x=>x.ParentID == categoryID);
        }

        public bool IsRoot(int categoryID)
        {
            throw new NotImplementedException();        }

        public int GetProductCount(int categoryID)
        {
            return db.Products.Count(x=>x.CategoryID== categoryID);
        }

        public bool HasProduct(int categoryID)
        {
            return db.Products.Any(x=>x.CategoryID== categoryID);
        }

        public bool ExitsCategoryName(string categoryName)
        {
           return db.Categories.Any(x=>x.CategoryName== categoryName);
        }

        public bool ExitsSlug(string slug)
        {
            return db.Categories.Any(x=>x.Slug== slug);
        }
        public bool HasChaid(int CategoryID)
        {
            return (db.Categories.Any(x=>x.ParentID== CategoryID));
        }

        public bool ExitsCategoryName(string categoryName, int CategoryID)
        {
            return db.Categories.Any(x => x.CategoryName == categoryName && x.CategoryID != CategoryID); ;
        }

        public bool ExitsSlug(string slug, int CategoryID)
        {
            return db.Categories.Any(x => x.Slug == slug && x.CategoryID != CategoryID);
        }

        public List<CategoryListItem> GetAllRoots()
        {
            return db.Categories.Where(x => x.ParentID == null).Select(ToListItem).ToList();
        }
    }
}
