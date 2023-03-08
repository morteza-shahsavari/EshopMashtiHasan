using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.RoleAction;


namespace EshopMashtiHasan.Controllers
{
    public class RoleActionManegmentController : Controller
    {
        private readonly IRoleActionBuss buss;
        public RoleActionManegmentController(IRoleActionBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(RoleActionSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult RoleActionSearchBoxAction(RoleActionSearchModel sm)
        {
            return ViewComponent("RoleActionSearchBox", sm);
        }
        public IActionResult RoleActionListAction(RoleActionSearchModel sm)
        {
            return ViewComponent("RoleActionList", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("RoleActionRegister");
        }
        [HttpPost]
        public JsonResult AddNewRoleAction(RoleActionAddModel RA)
        {
            return Json(buss.Register(RA));
        }
        public JsonResult RemoveRoleAction(int id)
        {
            return Json(buss.Delete(id));

        }
    }
}
