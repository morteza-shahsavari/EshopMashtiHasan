using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleActionRegister")]
    public class RoleActionRegisterViewComponent:ViewComponent
    {
        private readonly IRoleActionBuss buss;
        private readonly IProjectActionBuss conbuss;
        public RoleActionRegisterViewComponent(IRoleActionBuss buss, IProjectActionBuss conbuss)
        {
            this.buss = buss;
            this.conbuss = conbuss;
        }
        private void InflatedrpSearchRole()
        {
            var drpRole = buss.RoleDrps();
            drpRole.Insert(0, new RoleDrop { RoleID = -1, RoleName = "...Role..." });
            SelectList drpR = new SelectList(drpRole, "RoleID", "RoleName");
            ViewBag.drpRole = drpR;
        }
        private void InflatedrpSearchProjectController()
        {
            var drpProjectProjectController = conbuss.ProjectControllerDrops();
            drpProjectProjectController.Insert(0, new ProjectControllerDrop { ProjectControllerID = -1, ProjectControllerName = "...Controller..." });
            SelectList drpC = new SelectList(drpProjectProjectController, "ProjectControllerID", "ProjectControllerName");
            ViewBag.ProjectConrtoller = drpC;
        }
        private void InflatedrpSearchProjectAction()
        {
            var drpProjectProjectAction = buss.ProjectActionDrps();
            drpProjectProjectAction.Insert(0, new ProjectActionDrop { ProjectActionID = -1, ProjectActionName = "...Action..." });
            SelectList drpA = new SelectList(drpProjectProjectAction, "ProjectActionID", "ProjectActionName");
            ViewBag.ProjectAction = drpA;
        }
        public IViewComponentResult Invoke()
        {
            InflatedrpSearchRole();
          //  InflatedrpSearchProjectController();
            InflatedrpSearchProjectAction();
            return View();

        }
    }
}
