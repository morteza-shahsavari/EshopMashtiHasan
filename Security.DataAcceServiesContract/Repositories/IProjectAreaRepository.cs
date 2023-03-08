using Framework.Base;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAcceServiesContract.Repositories
{
    public interface IProjectAreaRepository:IBaseRepositorysearchable<ProjectArea,int, ProjectAreaSearchModel, ProjectAreaListItem, ProjectAreaUpdateModel, ProjectAreaAddModel>
    {
        bool ExitsAreaName(string AreaName);
        bool ExitsAreaName(string AreaName, int ProjectAreaID);

    }
}
