using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Security.BussinessServiceContract.Services;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProjectAreaRegister")]
    public class ProjectAreaRegisterViewComponent:ViewComponent
    {
        private readonly IProjectAreaBuss buss;
        public ProjectAreaRegisterViewComponent(IProjectAreaBuss buss)
        {
            this.buss = buss;
        }
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
