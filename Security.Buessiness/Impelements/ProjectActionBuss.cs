using Security.BussinessServiceContract.Services;
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

namespace Security.Buessiness.Impelements
{
    public class ProjectActionBuss : IProjectActionBuss
    {
        private readonly IProjectActionRepository repo;
        public ProjectActionBuss(IProjectActionRepository repo)
        {
            this.repo = repo;
        }

        public OperationResult Delete(int ProjectActionID)
        {
            return repo.Remove(ProjectActionID);
        }

        public OperationResult Delete()
        {
            return repo.DeleteAll();
        }

        public ProjectAction GetProjectAction(int ProjectActionID)
        {
            return repo.Get(ProjectActionID);
        }

        public int GetProjectController(string Controller)
        {
            return repo.GetProjectController(Controller);
        }

        public List<ProjectControllerDrop> ProjectControllerDrops()
        {
            return repo.ProjectControllerDrps().ToList();
        }

        public OperationResult Register(ProjectActionAddModel PA)
        {
            //if (repo.ExitsProjectActionName(PA.ProjectActionName))
            //{
            //    return new OperationResult("Register Project Action", "ProjectAction")
            //          .ToFail("Project Action Name Already Exist");
            //}
            if (PA.ProjectControllerID==null||PA.ProjectControllerID==-1)
            {
                return new OperationResult("Register Project Action", "ProjectAction")
                      .ToFail("Project Action controller Not Null ");
            }
            return repo.Add(PA);
        }
        public bool ExitsControllerActionName(int ControllerID, string ActionName)
        {
            return repo.ExitsControllerActionName(ControllerID, ActionName);
        }
        public List<ProjectActionListItem> Search(ProjectActionSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(ProjectActionUpdateModel PA)
        {
            if (repo.ExitsProjectActionName(PA.ProjectActionName, PA.ProjectActionID))
            {
                return new OperationResult("Update Project Action", "ProjectAction")
                      .ToFail("Project Action Name Already Exist");
            }
            return repo.Update(PA);
        }
    }
}
