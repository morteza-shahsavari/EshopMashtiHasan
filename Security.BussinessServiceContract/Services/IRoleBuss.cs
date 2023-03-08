using Framework.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.BussinessServiceContract.Services
{
    public interface IRoleBuss
    {
        OperationResult Register(RoleAddModel Role);
        OperationResult update(RoleUpdateModel Role);
        OperationResult Delete(int roleID);
        List<RoleListItem> Search(RoleSearchModel sm, out int RecordCount);
        Role GetRole(int roleID);
    }
}
