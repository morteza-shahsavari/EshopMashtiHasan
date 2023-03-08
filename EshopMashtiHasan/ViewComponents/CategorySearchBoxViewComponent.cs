using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "CategorySearchBox")]
    public class CategorySearchBoxViewComponent: ViewComponent
    {
        private readonly ICategoryBuss CatBuss;
        public CategorySearchBoxViewComponent(ICategoryBuss catBuss)
        {
            CatBuss = catBuss;
        }
        private void InflatedrapSearchCategory()
        {
            var FristLevelCategory = CatBuss.GetAllRoots();
            FristLevelCategory.Insert(0, new CategoryListItem { CategoryID = -1, CategoryName = "...رده والد..." });
            SelectList drp = new SelectList(FristLevelCategory, "CategoryID", "CategoryName");
            ViewBag.drp = drp;
        }
        public IViewComponentResult Invoke(CategorySearchModel sm)
        {
            InflatedrapSearchCategory();
            return View(sm);
        }
    }
}
