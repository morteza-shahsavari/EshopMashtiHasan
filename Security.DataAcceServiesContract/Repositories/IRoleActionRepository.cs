using Framework.Base;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAcceServiesContract.Repositories
{
    public interface IRoleActionRepository:IBaseRepositorysearchable<RoleAction,int,RoleActionSearchModel,RoleActionListItem,RoleActionUpdateModel,RoleActionAddModel>
    {

        public List<RoleDrop> RoleDrps();
        public List<ProjectActionDrop> ProjectActionDrps();
    }
}
