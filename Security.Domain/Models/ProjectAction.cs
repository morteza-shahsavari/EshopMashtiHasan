using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models
{
    public class ProjectAction
    {
        public int ProjectActionID { get; set; }
        public string ProjectActionName { get; set; }
        public string PersianTitle { get; set; }
        public ProjectController ProjectController { get; set; }
        public int ProjectControllerID { get; set; }
        public ICollection<RoleAction> RoleActions { get; set; }

        public ProjectAction()
        {
           this.RoleActions = new List<RoleAction>();
        }
    }
}
