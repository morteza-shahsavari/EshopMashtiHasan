using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;

namespace EshopMashtiHasan.Controllers
{
    public class ProjectControllerManegmentController : Controller
    {
        private readonly IProjectControllerBuss buss;
        public ProjectControllerManegmentController(IProjectControllerBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(ProjectControllerSearchModel sm)
        {
            return View(sm);
        }
     
        public IActionResult ProjectControllerSearchBoxAction(ProjectControllerSearchModel sm)
        {
            return ViewComponent("ProjectControllerSearchBox", sm);
        }
        public IActionResult ProjectControllerListAction(ProjectControllerSearchModel sm)
        {
            return ViewComponent("ProjectControllerList", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("ProjectControllerRegister");
        }
        [HttpPost]
        public JsonResult AddNewProjectController(ProjectControllerAddModel PC)
        {
            return Json(buss.Register(PC));
        }
        public JsonResult RemoveProjectControllerAction(int id)
        {
            return Json(buss.Delete(id));
        }
    }
}
