using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectArea;

namespace EshopMashtiHasan.Controllers
{
    public class ProjectAreaManegmentController : Controller
    {
        private readonly IProjectAreaBuss buss;
        public ProjectAreaManegmentController(IProjectAreaBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(ProjectAreaSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult ProjectAreaSearchBoxAction(ProjectAreaSearchModel sm)
        {
            return ViewComponent("ProjectAreaSearchBox", sm);
        }
        public IActionResult ProjectAreaListAction(ProjectAreaSearchModel sm)
        {
            return ViewComponent("ProjectAreaList", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("ProjectAreaRegister");
        }
        [HttpPost]
        public JsonResult AddNewProjectArea(ProjectAreaAddModel area)
        {
            return Json(buss.Register(area));
        }
        public JsonResult RemoveProjectArea(int id)
        {
            return Json(buss.Delete(id));

        }
    }

 }
