using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectArea;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectAreaList")]
    public class ProjectAreaListViewComponent:ViewComponent
    {
        private readonly IProjectAreaBuss buss;
        public ProjectAreaListViewComponent(IProjectAreaBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(ProjectAreaSearchModel sm)
        {
          
            if (sm == null || sm.PageSize == 0) { sm.PageSize = 20; }
            int rc = 0;
            var PA = buss.Search(sm, out rc);
            return View(PA);

        }
    }
}
