using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectControllerSearchBox")]
    public class ProjectControllerSearchBoxViewComponent:ViewComponent
    {
        private readonly IProjectControllerBuss buss;
        public ProjectControllerSearchBoxViewComponent(IProjectControllerBuss buss)
        {
            this.buss = buss;
        }
        private void InflatedrpSearchArea()
        {
            var drpProjectArea = buss.ProjectAreaDrps();
            drpProjectArea.Insert(0, new ProjectAreaDrop { ProjectAreaID = -1, AreaName = "...Area..." });
            SelectList drpArea = new SelectList(drpProjectArea, "ProjectAreaID", "AreaName");
            ViewBag.drpArea = drpArea;
        }
        public IViewComponentResult Invoke(ProjectControllerSearchModel sm)
        {
            InflatedrpSearchArea();
            return View(sm);

        }
    }
}
