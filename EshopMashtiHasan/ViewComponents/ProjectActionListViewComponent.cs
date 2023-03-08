using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectActionList")]
    public class ProjectActionListViewComponent:ViewComponent
    {
        private readonly IProjectActionBuss buss;
        public ProjectActionListViewComponent(IProjectActionBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(ProjectActionSearchModel sm)
        {
            if (sm.ProjectControllerID == -1)
            {
                sm.ProjectControllerID= null;
            }
            if (sm == null || sm.PageSize == 0) { sm.PageSize = 20; }
            int rc = 0;
            var PA = buss.Search(sm, out rc);
            return View(PA);

        }
    }
}
