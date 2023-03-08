using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.RoleAction;

namespace EshopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleActionList")]
    public class RoleActionListViewComponent : ViewComponent
    {
        private readonly IRoleActionBuss buss;
        public RoleActionListViewComponent(IRoleActionBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(RoleActionSearchModel sm)
        {
            if (sm.RoleID == -1)
            {
                sm.RoleID = null;
            }
            if (sm.ProjectActionID == -1)
            {
                sm.ProjectActionID = null;
            }
            if (sm == null || sm.PageSize == 0) { sm.PageSize = 20; }
            int rc = 0;
            var RA = buss.Search(sm, out rc);
            return View(RA);

        }
    }
}
