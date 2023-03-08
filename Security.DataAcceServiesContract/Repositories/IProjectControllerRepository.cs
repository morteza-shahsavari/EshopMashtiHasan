using Microsoft.EntityFrameworkCore;
using Framework.Base;
using Framework.BaseModel;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAcceServiesContract.Repositories
{
    public interface IProjectControllerRepository:IBaseRepositorysearchable<ProjectController,int, ProjectControllerSearchModel, ProjectControllerListItem, ProjectControllerUpdateModel, ProjectControllerAddModel>
    {
        bool ExitsProjectControllerName(string ProjectControllerName);
        bool ExitsProjectControllerName(string ProjectControllerName, int ProjectControllerID);
        public List<ProjectAreaDrop> ProjectAreaDrps();
        public OperationResult DeleteAll();
    }
}
