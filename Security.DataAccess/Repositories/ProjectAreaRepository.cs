using Security.DataAcceServiesContract.Repositories;
using Framework.BaseModel;

using Security.Domain.DTO.ProjectArea;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class ProjectAreaRepository : IProjectAreaRepository
    {
        private readonly SecurityContext db;
        public ProjectAreaRepository(SecurityContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ProjectAreaAddModel model)
        {
            var op = new OperationResult("Add Area", "Area");
            try
            {
                var Ar = new ProjectArea
                {
                    AreaName= model.AreaName,
                    PersianTitle= model.PersianTitle
                };
                db.ProjectAreas.Add(Ar);
                db.SaveChanges();
                
                return op.ToSuccess(Ar.ProjectAreaID, "Add Area Successfuly");
            }
            catch (Exception ex)
            {
                return op.ToFail("Add Area Fail" + ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete Area", "Area");
            try
            {
                var A = db.ProjectAreas.FirstOrDefault(x => x.ProjectAreaID == id);
                db.ProjectAreas.Remove(A);
                db.SaveChanges();
                return op.ToSuccess(id, "Delete Area Successfully");
            }
            catch (Exception ex)
            {

                return op.ToFail(id, "Delete Area to Fail" + ex.Message);
            }
        }

        public bool ExitsAreaName(string AreaName)
        {
            return db.ProjectAreas.Any(x => x.AreaName == AreaName);
        }

        public bool ExitsAreaName(string AreaName, int ProjectAreaID)
        {
            return db.ProjectAreas.Any(x => x.AreaName == AreaName && x.ProjectAreaID != ProjectAreaID);
        }

        public ProjectArea Get(int id)
        {
           return db.ProjectAreas.FirstOrDefault(x=>x.ProjectAreaID==id);
        }

        public List<ProjectArea> GetAll()
        {
            return db.ProjectAreas.ToList();
        }

        public List<ProjectAreaListItem> Search(ProjectAreaSearchModel sm, out int RecordCount)
        {
            var q = from item in db.ProjectAreas select item;
            if (!string.IsNullOrEmpty(sm.AreaName))
            {
                q = q.Where(x => x.AreaName.StartsWith(sm.AreaName));
            }
   
            RecordCount = q.Count();
            return q.Select(x => new ProjectAreaListItem
            {
              PersianTitle=x.PersianTitle,
              ProjectAreaID=x.ProjectAreaID,
              AreaName=x.AreaName
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(ProjectAreaUpdateModel model)
        {
            var op = new OperationResult("Update Area", "Area");
            try
            {
                var A = db.ProjectAreas.FirstOrDefault(x => x.ProjectAreaID == model.ProjectAreaID);
                A.AreaName=model.AreaName;
                A.PersianTitle=model.PersianTitle;
                db.SaveChanges();
                return op.ToSuccess("Update Area Successfuly");
            }
            catch (Exception ex)
            {

                return op.ToFail("Update Area Fail" + ex.Message);
            }
        }
    }
}
