using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectControllerList")]
    public class ProjectControllerListViewComponent : ViewComponent
    {
        private readonly IProjectControllerBuss buss;
        public ProjectControllerListViewComponent(IProjectControllerBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(ProjectControllerSearchModel sm)
        {
            if (sm.ProjectAreaID == -1)
            {
                sm.ProjectAreaID = null;
            }
            if (sm == null || sm.PageSize == 0) { sm.PageSize = 20; }
            int rc = 0;
            var PC = buss.Search(sm, out rc);
            return View(PC);
        }
    }
}
