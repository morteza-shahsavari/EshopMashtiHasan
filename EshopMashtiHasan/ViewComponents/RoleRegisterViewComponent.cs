using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleRegister")]
    public class RoleRegisterViewComponent:ViewComponent
    {
        private readonly IRoleBuss buss;
        public RoleRegisterViewComponent(IRoleBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
