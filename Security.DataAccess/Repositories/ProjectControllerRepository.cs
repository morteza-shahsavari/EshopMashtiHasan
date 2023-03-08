using Security.DataAcceServiesContract.Repositories;
using Framework.BaseModel;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class ProjectControllerRepository : IProjectControllerRepository
    {
        private readonly SecurityContext db;
        public ProjectControllerRepository(SecurityContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ProjectControllerAddModel model)
        {
            OperationResult op = new OperationResult("Add Controller", "Project Controller");
            try
            {
                var cont = new ProjectController
                {
                    ProjectControllerName= model.ProjectControllerName,
                    PersianTitle= model.PersianTitle,
                    ProjectAreaID= model.ProjectAreaID,
                };
                db.ProjectControllers.Add(cont);
                db.SaveChanges();
               
                return op.ToSuccess(cont.ProjectControllerID, "Add controller Successfuly");
            }
            catch (Exception ex)
            {

             return   op.ToFail("Add Controller Fail" + ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete Controller", "Controller");
            try
            {
                var cont = db.ProjectControllers.FirstOrDefault(x => x.ProjectControllerID == id);
                db.ProjectControllers.Remove(cont);
                db.SaveChanges();
                return op.ToSuccess(id, "Delete Controller Successfully");
            }
            catch (Exception ex)
            {

                return op.ToFail(id, "Delete Controller to Fail" + ex.Message);
            }
        }

        public bool ExitsProjectControllerName(string ProjectControllerName)
        {
            return db.ProjectControllers.Any(x => x.ProjectControllerName == ProjectControllerName );
        }

        public bool ExitsProjectControllerName(string ProjectControllerName, int ProjectControllerID)
        {
            return db.ProjectControllers.Any(x => x.ProjectControllerName == ProjectControllerName && x.ProjectControllerID != ProjectControllerID);
        }

        public ProjectController Get(int id)
        {
            return db.ProjectControllers.FirstOrDefault(x => x.ProjectControllerID == id);
        }

        public List<ProjectController> GetAll()
        {
            return db.ProjectControllers.ToList();
        }

        public List<ProjectAreaDrop> ProjectAreaDrps()
        {
            var q = from item in db.ProjectAreas select item;
            return q.Select(x => new ProjectAreaDrop
            {
                ProjectAreaID = x.ProjectAreaID,
                AreaName = x.AreaName
            }).ToList();
        }
        
        public OperationResult Update(ProjectControllerUpdateModel model)
        {
            var op = new OperationResult("Update Controller", "Controller");
            try
            {
                var cont = db.ProjectControllers.FirstOrDefault(x => x.ProjectControllerID == model.ProjectControllerID);
               cont.ProjectAreaID=model.ProjectAreaID;
                cont.ProjectControllerName=model.ProjectControllerName;
                cont.PersianTitle=model.PersianTitle;
                db.SaveChanges();
                return op.ToSuccess("Update Controller Successfuly");
            }
            catch (Exception ex)
            {

                return op.ToFail("Update Controller Fail" + ex.Message);
            }
        }

        public List<ProjectControllerListItem> Search(ProjectControllerSearchModel sm, out int RecordCount)
        {
            var q = from item in db.ProjectControllers select item;
            if (!string.IsNullOrEmpty(sm.ProjectControllerName))
            {
                q = q.Where(x => x.ProjectControllerName.StartsWith(sm.ProjectControllerName));
            }
            if (sm.ProjectControllerID != null)
            {
                q = q.Where(x => x.ProjectControllerID == sm.ProjectControllerID);
            }
            if (sm.ProjectAreaID != null)
            {
                q = q.Where(x => x.ProjectAreaID == sm.ProjectAreaID);
            }
            RecordCount = q.Count();
            return q.Select(x => new ProjectControllerListItem
            {
                ProjectControllerID = x.ProjectControllerID,
                ProjectControllerName = x.ProjectControllerName,
                PersianTitle = x.PersianTitle,
                AreaName = x.ProjectArea.AreaName
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult DeleteAll()
        {
            var q= db.ProjectControllers.ToList();
            foreach (var item in q)
            {
                db.ProjectControllers.Remove(item);
                db.SaveChanges();
            }
          return   new OperationResult ("DeleteAll","Project Controller").ToSuccess("SuccessFully");
        }
    }
}
