using EshopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shopping.BussinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;

namespace EshopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]

    public class CategoryManegementController : Controller
    {
        private readonly ICategoryBuss CatBuss;
        public CategoryManegementController(ICategoryBuss catBuss)
        {
           this.CatBuss = catBuss;
        }
        public IActionResult CategorySearchBoxAction(CategorySearchModel sm)
        {
            return ViewComponent("CategorySearchBox", sm);
        }
        public IActionResult Index(CategorySearchModel sm)
        {
            return View(sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("RegisterCategory");
        }
        [HttpPost]
        public JsonResult AddNew(CategoryAddModel cat)
        {
            var op = CatBuss.RegisterCategory(cat);
            return Json(op);
        }
        public IActionResult CategoryListAction(CategorySearchModel sm)
        {
            return ViewComponent("CategoryList",sm);
        }
        public JsonResult Delete(int id)
        {
            var op = CatBuss.RemoveCategory(id);
            return Json(op);
        }
    }
}
