using Framework.Base;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAcceServiesContract.Repositories
{
    public interface IUserRepository:IBaseRepositorysearchable<User,int,UserSearchModel,UserListItem,UserUpdateModel,UserAddModel>
    {
        bool ExitsUserName(string UserName);
        bool ExitsUserName(string UserName, int UserID);
        public List<RoleDrop> RoleDrps();
    }
}
