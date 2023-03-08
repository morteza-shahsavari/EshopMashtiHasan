using Framework.BaseModel;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.RoleAction
{
    public class RoleActionSearchModel:PageModel
    {
        public int? RoleActionID { get; set; }
        public int? RoleID { get; set; }
        public int? ProjectActionID { get; set; }
    }
}
