using Framework.BaseModel;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.ProjectController
{
    public class ProjectControllerSearchModel:PageModel
    {
        public int? ProjectControllerID { get; set; }
        public string ProjectControllerName { get; set; }
        public int? ProjectAreaID { get; set; }
    }
}
