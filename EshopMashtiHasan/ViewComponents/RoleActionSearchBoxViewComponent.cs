using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleActionSearchBox")]
    public class RoleActionSearchBoxViewComponent : ViewComponent
    {
        private readonly IRoleActionBuss buss;
        public RoleActionSearchBoxViewComponent(IRoleActionBuss buss)
        {
            this.buss = buss;
        }
        private void InflatedrpSearchRole()
        {
            var drpProjectRole = buss.RoleDrps();
            drpProjectRole.Insert(0, new RoleDrop { RoleID = -1, RoleName = "...Role..." });
            SelectList drpR = new SelectList(drpProjectRole, "RoleID", "RoleName");
            ViewBag.drpRole = drpR;
        }
        private void InflatedrpSearchProjectAction()
        {
            var drpProjectProjectAction = buss.ProjectActionDrps();
            drpProjectProjectAction.Insert(0, new ProjectActionDrop { ProjectActionID = -1, ProjectActionName = "...Action..." });
            SelectList drpA = new SelectList(drpProjectProjectAction, "ProjectActionID", "ProjectActionName");
            ViewBag.ProjectAction = drpA;
        }
        public IViewComponentResult Invoke(RoleActionSearchModel sm)
        {
            InflatedrpSearchRole();
            InflatedrpSearchProjectAction();
            return View(sm);

        }
    }
}
