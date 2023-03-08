using Security.BussinessServiceContract.Services;
using Security.DataAcceServiesContract.Repositories;
using Framework.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Security.Framework;

namespace Security.Buessiness.Impelements
{
    public class UserBuss : IUserBuss
    {
        private readonly IUserRepository repo;
        public UserBuss(IUserRepository repo)
        {
            this.repo = repo;
        }

        public OperationResult Delete(int userID)
        {
            return repo.Remove(userID) ;
        }

        public User GetUser(int userID)
        {
            return repo.Get(userID);
        }

        public OperationResult Register(UserAddModel user)
        {
            if (repo.ExitsUserName(user.UserName))
            {
                return new OperationResult("Register User", "User")
                      .ToFail("Username Already Exist");
            }
            if (user.RoleID == null || user.RoleID == -1)
            {
                return new OperationResult("Register User", "User")
                      .ToFail("Role Not Null ");
            }
            
            return repo.Add(user);
        }

        public List<RoleDrop> RoleDrps()
        {
            return repo.RoleDrps().ToList();
        }

        public List<UserListItem> Search(UserSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(UserUpdateModel user)
        {
            if (repo.ExitsUserName(user.UserName, user.UserID))
            {
              return new OperationResult("Update User", "User")
                    .ToFail("Username Already Exist");
            }
            return repo.Update(user);
        }
    }
}
