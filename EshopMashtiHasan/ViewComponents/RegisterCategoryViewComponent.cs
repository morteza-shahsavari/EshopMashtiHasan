using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RegisterCategory")]
    public class RegisterCategoryViewComponent:ViewComponent
    {
        private readonly ICategoryBuss buss;
        public RegisterCategoryViewComponent(ICategoryBuss buss)
        {
            this.buss = buss;
        }
        private void InflatedrapSearchCategory()
        {
            var FristLevelCategory = buss.GetAllRoots();
            FristLevelCategory.Insert(0,new CategoryListItem{CategoryID=-1,CategoryName="...رده والد..." });
            SelectList drp = new SelectList(FristLevelCategory, "CategoryID", "CategoryName");
            ViewBag.drp = drp;
        }
        public IViewComponentResult Invoke()
        {
            InflatedrapSearchCategory();
            return View();
        }
    }
}
