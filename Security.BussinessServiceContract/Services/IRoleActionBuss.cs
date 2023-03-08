using Framework.BaseModel;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.BussinessServiceContract.Services
{
    public interface IRoleActionBuss
    {
        OperationResult Register(RoleActionAddModel RoleAction);
        OperationResult update(RoleActionUpdateModel RoleAction);
        OperationResult Delete(int RoleActionID);
        List<RoleActionListItem> Search(RoleActionSearchModel sm, out int RecordCount);
        RoleAction GetRoleAction(int RoleActionID);
        List<RoleDrop> RoleDrps();
        List<ProjectActionDrop> ProjectActionDrps();
    }
}
