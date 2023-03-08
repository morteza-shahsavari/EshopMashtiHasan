using Microsoft.EntityFrameworkCore;
using Security.DataAcceServiesContract.Repositories;
using Framework.BaseModel;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class RoleActionRepository : IRoleActionRepository
    {
        private readonly SecurityContext db;
        public RoleActionRepository(SecurityContext db)
        {
            this.db = db;
        }
        public OperationResult Add(RoleActionAddModel model)
        {
            OperationResult op = new OperationResult("Add Role Action", "RoleAction");
            try
            {
                var RA = new RoleAction
                {
                    HasPermission= model.HasPermission,
                    RoleID= model.RoleID,
                    ProjectActionID= model.ProjectActionID
                };
                db.RoleActions.Add(RA);
                db.SaveChanges();
                return op.ToSuccess(RA.RoleActionID,"Add RoleAction Successfully");
            }
            catch (Exception ex)
            {

                return op.ToFail("Add Role Action ToFail"+ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete RoleAction", "RoleAction");
            try
            {
                var ra = db.RoleActions.FirstOrDefault(x => x.RoleActionID == id);
                db.RoleActions.Remove(ra);
                db.SaveChanges();
                return op.ToSuccess(id, "Delete Role Action Successfully");
            }
            catch (Exception ex)
            {

                return op.ToFail(id, "Delete Role Action to Fail" + ex.Message);
            }
        }

        public RoleAction Get(int id)
        {
            return db.RoleActions.FirstOrDefault(x => x.RoleActionID == id);
        }

        public List<RoleAction> GetAll()
        {
            return db.RoleActions.ToList();
        }

        public List<ProjectActionDrop> ProjectActionDrps()
        {
            var q = from item in db.ProjectActions select item;
            return q.Select(x => new ProjectActionDrop
            {
                ProjectActionID = x.ProjectActionID,
                ProjectActionName = x.ProjectActionName
            }).ToList();
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

        public List<RoleActionListItem> Search(RoleActionSearchModel sm, out int RecordCount)
        {
            var q = from item in db.RoleActions select item;

            if (sm.RoleID != null)
            {
                q = q.Where(x => x.RoleID == sm.RoleID);
            }
            if (sm.RoleActionID != null)
            {
                q = q.Where(x => x.RoleActionID == sm.RoleActionID);
            }
            if (sm.ProjectActionID != null)
            {
                q = q.Where(x => x.ProjectActionID == sm.ProjectActionID);
            }
            RecordCount = q.Count();
            return q.Select(x => new RoleActionListItem
            {
                RoleActionID = x.RoleActionID,
                RoleName = x.Role.RoleName,
                ProjectActionName = x.ProjectAction.ProjectActionName,
                HasPermission = x.HasPermission,
                ProjectControllerName = x.ProjectAction.ProjectController.ProjectControllerName
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(RoleActionUpdateModel model)
        {
            var op = new OperationResult("Update RoleAction", "RoleAction");
            try
            {
                var ra = db.RoleActions.FirstOrDefault(x => x.RoleActionID == model.RoleActionID);
                ra.HasPermission=model.HasPermission;
                ra.RoleID= model.RoleID;
                ra.ProjectActionID= model.ProjectActionID;
                db.SaveChanges();
                return op.ToSuccess("Update RoleAction Successfuly");
            }
            catch (Exception ex)
            {
                return op.ToFail("Update RoleAction Fail" + ex.Message);
            }
        }
    }
}
