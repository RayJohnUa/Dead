using DeadEntity;
using DeadEntity.IRepository;
using DeadProject.Helpers;
using DeadProject.Models;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace DeadProject.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        
        public AuthController(IUserRepository repository)
        {
            _userRepository = repository;
        } 

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            UserEntity user = _userRepository.GetUserbyMailandPassword(model.Email , HashPasswordHelpers.GenerateHash(model.Password));
            if (user != null && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(user.Token , false);
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("User", "Email or Password is incorrect!");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            bool isEmailExist = _userRepository.IsEmailIsExist(model.Email);
            if (!isEmailExist && ModelState.IsValid)
            {
                UserEntity user = new UserEntity() {Email = model.Email , FirstName = model.FirstName , LastName = model.LastName , Password = HashPasswordHelpers.GenerateHash(model.Password)};
                _userRepository.Add(user);
            }
            if (isEmailExist)
            {
                ModelState.AddModelError("Email", "This Email is already exist!");
            }
            return View();
        }

        public void Logout()
        {
            _userRepository.DeleteUserHash(HttpContext.User.Identity.Name);
            FormsAuthentication.SignOut();
            RedirectToAction("Login" , "Auth");
        }
    }
}