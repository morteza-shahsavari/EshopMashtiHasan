using Microsoft.AspNetCore.Mvc;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using Security.Framework.Services;

namespace EshopMashtiHasan.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountBuss buss;
        private readonly IUserBuss UserBuss;
        private readonly IPasswordHasher PasswordHasher;
        public AccountController(IAccountBuss buss, IPasswordHasher PasswordHasher, IUserBuss UserBuss)
        {
            this.buss = buss;
            this.PasswordHasher = PasswordHasher;
            this.UserBuss = UserBuss;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Security.Domain.DTO.User.Login l)
        {
            var op = buss.Login(l);
            if (!op.Success)
            {
                ViewBag.ErrorMessage = op.Message;
                return View(l);
            }

            //TODO 

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAddModel u)
        {
            u.RoleID = 2;//Customer
            u.Password = PasswordHasher.Hash(u.Password);
            UserBuss.Register(u);
            //buss.Register(u);
            return View();
        }
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}

