using Security.BussinessServiceContract.Services;
using Security.DataAcceServiesContract.Repositories;
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

namespace Security.Buessiness.Impelements
{
    public class RoleActionBuss : IRoleActionBuss
    {
        private readonly IRoleActionRepository repo;
        public RoleActionBuss(IRoleActionRepository repo)
        {
            this.repo = repo;
        }

        public OperationResult Delete(int RoleActionID)
        {
            return repo.Remove(RoleActionID);
        }

        public Domain.Models.RoleAction GetRoleAction(int RoleActionID)
        {
            return repo.Get(RoleActionID);
        }

        public List<ProjectActionDrop> ProjectActionDrps()
        {
            return repo.ProjectActionDrps().ToList();
        }

        public OperationResult Register(RoleActionAddModel RoleAction)
        {
            if (RoleAction.RoleID == null || RoleAction.RoleID == -1)
            {
                return new OperationResult("Register Role", "Role")
                      .ToFail("Role Not Null ");
            }
            if (RoleAction.ProjectActionID == null || RoleAction.ProjectActionID == -1)
            {
                return new OperationResult("Register ProjectAction", "ProjectAction")
                      .ToFail("ProjectAction Not Null ");
            }
            return repo.Add(RoleAction);
        }

        public List<RoleDrop> RoleDrps()
        {
            return repo.RoleDrps().ToList();
        }

        public List<RoleActionListItem> Search(RoleActionSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(RoleActionUpdateModel RoleAction)
        {
            return repo.Update(RoleAction);
        }
    }
}
