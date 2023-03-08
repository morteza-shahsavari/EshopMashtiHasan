using Framework.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.BussinessServiceContract.Services
{
    public interface IUserBuss
    {
       OperationResult Register(UserAddModel user);
        OperationResult update(UserUpdateModel user);
        OperationResult Delete(int userID);
        List<UserListItem> Search(UserSearchModel sm, out int RecordCount);
        User GetUser(int userID);
        List<RoleDrop> RoleDrps();
    }
}
