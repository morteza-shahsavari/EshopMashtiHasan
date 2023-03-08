using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectAreaSearchBox")]
    public class ProjectAreaSearchBoxViewComponent : ViewComponent
    {
      
            private readonly IProjectAreaBuss buss;
            public ProjectAreaSearchBoxViewComponent(IProjectAreaBuss buss)
            {
                this.buss = buss;
            }
            public IViewComponentResult Invoke(ProjectAreaSearchModel sm)
            {
                return View(sm);
            }
        
    }
}
