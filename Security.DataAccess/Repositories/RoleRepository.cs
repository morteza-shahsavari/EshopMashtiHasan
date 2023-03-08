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

namespace Security.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SecurityContext db;
        public RoleRepository(SecurityContext db)
        {
            this.db = db;
        }
        public OperationResult Add(RoleAddModel model)
        {
            OperationResult op = new OperationResult("Add Role", "Role");
            try
            {
                var r = new Role
                {
                    RoleName= model.RoleName
                };
                db.Roles.Add(r);
                db.SaveChanges();
               
                return op.ToSuccess(r.RoleID, "Add Role Successfully");
            }
            catch (Exception ex)
            {

                return op.ToFail("Add Role ToFail" + ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete Role", "Role");
            try
            {
                var ro = db.Roles.FirstOrDefault(x => x.RoleID == id);
                db.Roles.Remove(ro);
                db.SaveChanges();
                return op.ToSuccess(id, "Delete Role Successfully");
            }
            catch (Exception ex)
            {

                return op.ToFail(id, "Delete Role to Fail" + ex.Message);
            }
        }

        public bool ExitsRoleName(string RoleName)
        {
            return db.Roles.Any(x => x.RoleName == RoleName);
        }

        public bool ExitsRoleName(string RoleName, int RoleID)
        {
            return db.Roles.Any(x => x.RoleName == RoleName && x.RoleID != RoleID);
        }

        public Role Get(int id)
        {
            return db.Roles.FirstOrDefault(x => x.RoleID == id);
        }

        public List<Role> GetAll()
        {
            return db.Roles.ToList();
        }

        public int GetUserCount(int RoleID)
        {
            return db.Users.Count(x=>x.RoleID== RoleID);
        }
         public OperationResult Update(RoleUpdateModel model)
        {
            var op = new OperationResult("Update Role", "Role");
            try
            {
                var r = db.Roles.FirstOrDefault(x => x.RoleID == model.RoleID);
                r.RoleName=model.RoleName;
                db.SaveChanges();
                return op.ToSuccess("Update Role Successfuly");
            }
            catch (Exception ex)
            {
                return op.ToFail("Update Role Fail" + ex.Message);
            }
        }

        public List<RoleListItem> Search(RoleSearchModel sm, out int RecordCount)
        {
            var q = from item in db.Roles select item;
            if (!string.IsNullOrEmpty(sm.RoleName))
            {
                q = q.Where(x => x.RoleName.StartsWith(sm.RoleName));
            }
          
            RecordCount = q.Count();
            return q.Select(x => new RoleListItem
            {
               RoleName= x.RoleName,
               RoleID= x.RoleID,
               UserCount=x.Users.Any()? x.Users.Count() : 0,
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

      
        public List<UserListItem> UserList(int RoleID)
        { 
            var q=db.Users.Where(x=>x.RoleID == RoleID);
            return q.Select(x => new UserListItem
            {
               UserID= x.UserID,
               UserName=x.UserName,
               Password=x.Password,
               Email=x.Email,
               Mobile=x.Mobile,
               FirstName=x.FirstName,
               LastName=x.LastName,
               RoleName=x.Role.RoleName
            }).ToList();
        }
    }
}
