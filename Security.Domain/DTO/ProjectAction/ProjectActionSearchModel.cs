
using Framework.BaseModel;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.ProjectAction
{
    public class ProjectActionSearchModel:PageModel
    {
        public string ProjectActionName { get; set; }
        public int? ProjectControllerID { get; set; }

    }
}
