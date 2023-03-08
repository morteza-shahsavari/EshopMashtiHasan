using EshopMashtiHasan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using System.Reflection;

namespace EshopMashtiHasan.Controllers
{
    public class ReflectorController : Controller
    {
        private readonly IProjectControllerBuss bussCont;
        private readonly IProjectActionBuss bussAct;
        public ReflectorController(IProjectControllerBuss bussCont, IProjectActionBuss bussAct)
        {
            this.bussCont = bussCont;
            this.bussAct = bussAct;
        }
       
      
        public IActionResult Index()
        {
            var q = In();
            return View(q);
        }
        public IActionResult I()
        {
            var q = GetAllControllersAndTheirActions();
            return View(q);
        }
        public List<ControllerActions> In()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Select(x => new
                    {
                        Controller = x.DeclaringType.Name,
                        Action = x.Name,
                        Area = x.DeclaringType.CustomAttributes.Where(c => c.AttributeType == typeof(AreaAttribute))

                    }).ToList();
            var list = new List<ControllerActions>();
            foreach (var item in controlleractionlist)
            {
                if (item.Area.Count() != 0)
                {
                    list.Add(new ControllerActions()
                    {
                        Controller = item.Controller,
                        Action = item.Action,
                        Area = item.Area.Select(v => v.ConstructorArguments[0].Value.ToString()).FirstOrDefault()
                    });
                }
                else
                {
                    list.Add(new ControllerActions()
                    {
                        Controller = item.Controller,
                        Action = item.Action,
                        Area = null,
                    });
                }
            }
            return list;
        }
        
            public static List<ControllerAndItsActions> GetAllControllersAndTheirActions()
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                IEnumerable<Type> controllers = asm.GetTypes().Where(type => type.Name.EndsWith("Controller"));
                var theList = new List<ControllerAndItsActions>();

                foreach (Type curController in controllers)
                {
                    List<string> actions = curController.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                        .Where(m => m.CustomAttributes.Any(a => typeof(HttpMethodAttribute).IsAssignableFrom(a.AttributeType)))
                        .Select(x => x.Name)
                        .ToList();

                    theList.Add(new ControllerAndItsActions(curController.Name, actions));
                }

                return theList;
            }
        public IActionResult Reflector()
        {
            //bussAct.Delete();
            // bussCont.Delete();
            var q = GetAllControllersAndTheirActions();
            foreach (var item in q)
            {
                var cont = new ProjectControllerAddModel
                {
                    ProjectControllerName = item.Controller.Replace("Controller", String.Empty),
                    ProjectAreaID = 1//وقتی Area   NUll  میشه ثبت نمیکنه به همین خاطر دستی اریا رو دستی دادم
                };
                bussCont.Register(cont);
            }
            var d = In();
            foreach (var item in d)
            {
                var PControllerID = bussAct.GetProjectController(item.Controller.Replace("Controller", String.Empty));
                if (bussAct.ExitsControllerActionName(PControllerID, item.Action))
                {
                }
                else
                {
                    var Act = new ProjectActionAddModel
                    {
                        ProjectActionName = item.Action,
                        ProjectControllerID = PControllerID,

                    };
                    bussAct.Register(Act);
                }
            }
            return View(d);
        }
    }
}
