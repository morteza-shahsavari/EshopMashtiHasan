using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.Role;

namespace EshopMashtiHasan.Controllers
{
    public class RoleManegmentController : Controller
    {
        private readonly IRoleBuss buss;
        public RoleManegmentController(IRoleBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(RoleSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult RoleSearchBoxAction(RoleSearchModel sm)
        {
            return ViewComponent("RoleSearchBox", sm);
        }
        public IActionResult RoleListAction(RoleSearchModel sm)
        {
            return ViewComponent("RoleList", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("RoleRegister");
        }
        [HttpPost]
        public JsonResult AddNewRole(RoleAddModel role)
        {
            var op = buss.Register(role);
            return Json(op);
        }
        public JsonResult RemoveRole(int id)
        {
            var op = buss.Delete(id);
            return Json(op);

        }
    }
}
