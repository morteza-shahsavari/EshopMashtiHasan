using Security.BussinessServiceContract.Services;
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

namespace Security.Buessiness.Impelements
{
    public class ProjectControllerBuss : IProjectControllerBuss
    {
        private readonly IProjectControllerRepository repo;
        public ProjectControllerBuss(IProjectControllerRepository repo)
        {
            this.repo = repo;
        }
                
        public OperationResult Delete(int ProjectControllerID)
        {
            return repo.Remove(ProjectControllerID);
        }

        public OperationResult Delete()
        {
           return repo.DeleteAll();
        }

        public ProjectController GetProjectController(int ProjectControllerID)
        {
            return repo.Get(ProjectControllerID);
        }

        public List<ProjectAreaDrop> ProjectAreaDrps()
        {
            return repo.ProjectAreaDrps().ToList();
        }

        public OperationResult Register(ProjectControllerAddModel cont)
        {
            if (repo.ExitsProjectControllerName(cont.ProjectControllerName))
            {
                return new OperationResult("Update ProjectController", "ProjectController")
                      .ToFail("ProjectController Name Already Exist");
            }
            //if (cont.ProjectAreaID == null || cont.ProjectAreaID == -1)
            //{
            //    return new OperationResult("Register Project Contorller", "ProjectContorller")
            //          .ToFail("Project Area Not Null ");
            //}
            return repo.Add(cont);
        }

        public List<ProjectControllerListItem> Search(ProjectControllerSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(ProjectControllerUpdateModel cont)
        {
            if (repo.ExitsProjectControllerName(cont.ProjectControllerName, cont.ProjectControllerID))
            {
                return new OperationResult("Update ProjectController", "ProjectController")
                      .ToFail("ProjectController Name Already Exist");
            }
            return repo.Update(cont);
        }
    }
}
