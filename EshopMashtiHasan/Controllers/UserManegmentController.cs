using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.User;
using Security.Framework.Services;

namespace EshopMashtiHasan.Controllers
{
    public class UserManegmentController : Controller
    {
        private readonly IUserBuss buss;
        private readonly IPasswordHasher PasswordHasher;
        public UserManegmentController(IUserBuss buss, IPasswordHasher PasswordHasher)
        {
            this.buss = buss;
            this.PasswordHasher = PasswordHasher;
        }

        public IActionResult Index(UserSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult UserSearchBoxAction(UserSearchModel sm)
        {
            return ViewComponent("UserSearchBox", sm);
        }
        public IActionResult UserListAction(UserSearchModel sm)
        {
            return ViewComponent("UserList", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("UserRegister");
        }
        [HttpPost]
        public JsonResult AddNewUser(UserAddModel user)
        {
            user.Password = PasswordHasher.Hash(user.Password);
            return Json(buss.Register(user));
        }
        public JsonResult RemoveRole(int id)
        {
            return Json(buss.Delete(id));

        }
    }
}
