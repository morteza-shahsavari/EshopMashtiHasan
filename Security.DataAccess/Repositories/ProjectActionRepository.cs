using Security.DataAcceServiesContract.Repositories;
using Framework.BaseModel;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class ProjectActionRepository : IProjectActionRepository
    {
        private readonly SecurityContext db;
        public ProjectActionRepository(SecurityContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ProjectActionAddModel model)
        {
            var op = new OperationResult("Add Action", "Action");
            try
            {
                var act = new ProjectAction
                {
                    ProjectActionName=model.ProjectActionName,
                    ProjectControllerID=model.ProjectControllerID,
                    PersianTitle=model.PersianTitle

                };
                db.ProjectActions.Add(act);
                db.SaveChanges();
               
                return op.ToSuccess(act.ProjectActionID,"Add Action Successfuly");
            }
            catch (Exception ex)
            {
                return op.ToFail("Add Action Fail" + ex.Message);
            }
        }
        public bool ExitsControllerActionName(int ControllerID, string ActionName)
        {
            return db.ProjectActions.Any(x => x.ProjectActionName == ActionName && x.ProjectControllerID == ControllerID);
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete Action", "Action");
            try
            {
                var Act = db.ProjectActions.FirstOrDefault(x => x.ProjectActionID == id);
                db.ProjectActions.Remove(Act);
                db.SaveChanges();
                return op.ToSuccess(id, "Delete Action Successfully");
            }
            catch (Exception ex)
            {

                return op.ToFail(id, "Delete Action to Fail" + ex.Message);
            }
        }

        public OperationResult DeleteAll()
        {
           
            
                var q = db.ProjectActions.ToList();
                foreach (var item in q)
                {
                    db.ProjectActions.Remove(item);
                    db.SaveChanges();
                }
                return new OperationResult("DeleteAll", "ProjectActions").ToSuccess("SuccessFully");
            
        }

        public bool ExitsProjectActionName(string ProjectActionName)
        {
            return db.ProjectActions.Any(x => x.ProjectActionName == ProjectActionName);
        }

        public bool ExitsProjectActionName(string ProjectActionName, int ProjectActionID)
        {
            return db.ProjectActions.Any(x => x.ProjectActionName == ProjectActionName && x.ProjectActionID != ProjectActionID);
        }

        public ProjectAction Get(int id)
        {
            return db.ProjectActions.FirstOrDefault(x=>x.ProjectActionID==id);
        }

        public List<ProjectAction> GetAll()
        {
            return db.ProjectActions.ToList();
        }

        public int GetProjectController(string Controller)
        {
           var q= db.ProjectControllers.FirstOrDefault(x=>x.ProjectControllerName==Controller);
            return q.ProjectControllerID;
        }

        public List<ProjectControllerDrop> ProjectControllerDrps()
        {
            var q = from item in db.ProjectControllers select item;
            return q.Select(x => new ProjectControllerDrop
            {
                ProjectControllerID = x.ProjectControllerID,
                ProjectControllerName = x.ProjectControllerName
            }).ToList();
        }

        public List<ProjectActionListItem> Search(ProjectActionSearchModel sm, out int RecordCount)
        {
            var q = from item in db.ProjectActions select item;
            if (!string.IsNullOrEmpty(sm.ProjectActionName))
            {
                q = q.Where(x => x.ProjectActionName.StartsWith(sm.ProjectActionName));
            }
            if (sm.ProjectControllerID != null)
            {
                q = q.Where(x => x.ProjectControllerID == sm.ProjectControllerID);
            }
            RecordCount = q.Count();
            return q.Select(x => new ProjectActionListItem
            {
                ProjectActionID=x.ProjectActionID,
                ProjectActionName=x.ProjectActionName,
                PersianTitle=x.PersianTitle,
                ProjectControllerName=x.ProjectController.ProjectControllerName
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(ProjectActionUpdateModel model)
        {
            var op = new OperationResult("Update Action", "Action");
            try
            {
                var act = db.ProjectActions.FirstOrDefault(x => x.ProjectActionID == model.ProjectActionID);
                act.ProjectActionName=model.ProjectActionName;
                act.ProjectControllerID=model.ProjectControllerID;
                act.PersianTitle=model.PersianTitle;
                db.SaveChanges();
                return op.ToSuccess("Update Action Successfuly");
            }
            catch (Exception ex)
            {

                return op.ToFail("Update Action Fail" + ex.Message);
            }
        }
    }
}
