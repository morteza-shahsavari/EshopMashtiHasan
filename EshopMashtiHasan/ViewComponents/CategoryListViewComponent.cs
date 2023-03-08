using Microsoft.AspNetCore.Mvc;
using shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "CategoryList")]
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly ICategoryBuss buss;
        public CategoryListViewComponent(ICategoryBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(CategorySearchModel sm)
        {
            if (sm.ParentID == -1)
            {
                sm.ParentID = null;
            }

            if (sm == null || sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            int rc = 0;
            var cats = buss.Search(sm, out rc);
            return View(cats);
        }
    }
}
