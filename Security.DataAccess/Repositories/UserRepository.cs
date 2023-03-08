using Security.DataAcceServiesContract.Repositories;
using Framework.BaseModel;
using Security.Framework;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SecurityContext db;
        public UserRepository(SecurityContext db)
        {
            this.db = db;
        }

        public OperationResult Add(UserAddModel model)
        {
            OperationResult op = new OperationResult("Add user", "user");
            try
            {

                var u = new User
                {
                    RoleID= model.RoleID,
                    UserName= model.UserName,
                    Password= model.Password,
                    LastName= model.LastName,
                    FirstName= model.FirstName,
                    Email= model.Email,
                    IsEmailActivated= model.IsEmailActivated,
                    Mobile  = model.Mobile
                };
                db.Users.Add(u);
                db.SaveChanges();
               
                return op.ToSuccess(u.RoleID, "Add user Successfully");
            }
            catch (Exception ex)
            {

                return op.ToFail("Add user ToFail" + ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete User","user");
            try
            {
                var user = db.Users.FirstOrDefault(x => x.UserID == id);
                db.Users.Remove(user);
                db.SaveChanges();
                return op.ToSuccess(id, "Delete User Successfully");
            }
            catch (Exception ex)
            {

                return op.ToFail(id, "Delete User to Fail" + ex.Message);
            }
        }

        public bool ExitsUserName(string UserName)
        {
            return db.Users.Any(x => x.UserName == UserName);
        }

        public bool ExitsUserName(string UserName, int UserID)
        {
            return db.Users.Any(x => x.UserName == UserName && x.UserID != UserID);
        }

        public User Get(int id)
        {
           return db.Users.FirstOrDefault(x=>x.UserID==id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public List<RoleDrop> RoleDrps()
        {
            var q = from item in db.Roles select item;
            return q.Select(x => new RoleDrop
            {
                RoleID = x.RoleID,
                RoleName = x.RoleName
            }).ToList();
        }

        public List<UserListItem> Search(UserSearchModel sm, out int RecordCount)
        {
            var q = from item in db.Users select item;
            if (!string.IsNullOrEmpty(sm.UserName))
            {
                q = q.Where(x => x.UserName.StartsWith(sm.UserName));
            }
            if (!string.IsNullOrEmpty(sm.LastName))
            {
                q = q.Where(x => x.LastName.StartsWith(sm.LastName));
            }
            if (!string.IsNullOrEmpty(sm.FirstName))
            {
                q = q.Where(x => x.FirstName.StartsWith(sm.FirstName));
            }
            if (!string.IsNullOrEmpty(sm.Mobile))
            {
                q = q.Where(x => x.Mobile.StartsWith(sm.Mobile));
            }
            if (sm.RoleID != null)
            {
                q = q.Where(x => x.RoleID == sm.RoleID);
            }

            RecordCount = q.Count();
            return q.Select(x => new UserListItem
            {
                UserID = x.UserID,
                UserName = x.UserName,
                Password = x.Password,
                Email = x.Email,
                Mobile = x.Mobile,
                FirstName = x.FirstName,
                LastName = x.LastName,
                RoleName = x.Role.RoleName
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(UserUpdateModel model)
        {
            var op = new OperationResult("Update User", "User");
            try
            {
                var r = db.Users.FirstOrDefault(x => x.UserID == model.UserID);
                r.UserName=model.UserName;
                r.Password=model.Password;
                r.LastName=model.LastName;
                r.FirstName=model.FirstName;
                r.Email=model.Email;
                r.Mobile=model.Mobile;
                r.IsEmailActivated=model.IsEmailActivated;
                r.RoleID= model.RoleID;
                db.SaveChanges();
                return op.ToSuccess("Update User Successfuly");
            }
            catch (Exception ex)
            {
                return op.ToFail("Update User Fail" + ex.Message);
            }
        }
    }
}
