using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;

namespace EshopMashtiHasan.Controllers
{
    public class ProjectActionManegmentController : Controller
    {
        private readonly IProjectActionBuss buss;
        public ProjectActionManegmentController(IProjectActionBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(ProjectActionSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult ProjectActionSearchBoxAction(ProjectActionSearchModel sm)
        {
            return ViewComponent("ProjectActionSearchBox", sm);
        }
        public IActionResult ProjectActionListAction(ProjectActionSearchModel sm)
        {
            return ViewComponent("ProjectActionList", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("ProjectActionRegister");
        }
        [HttpPost]
        public JsonResult AddNewProjectAction(ProjectActionAddModel acta)
        {
            return Json(buss.Register(acta));
        }
        public JsonResult RemoveProjectAction(int id)
        {
            return Json(buss.Delete(id));
        }
    }
}
