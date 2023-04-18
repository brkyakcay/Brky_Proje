using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Obs_Proje.Data;
using Obs_Proje.Models;

namespace Obs_Proje.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly SignInManager<WebUser> _signInManager;

        //private readonly UserManager<WebRole> _userManagerx;
        //private readonly SignInManager<WebRole> _signInManagerx;

        public AccountController(UserManager<WebUser> userManager, SignInManager<WebUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //public AccountController(UserManager<WebRole> userManagerx, SignInManager<WebRole> signInManagerx)
        //{
        //    _userManagerx = userManagerx;
        //    _signInManagerx = signInManagerx;
        //}

        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterUserModel model)
        {
            var newUser = new WebUser
            {

                //Fullname = model.Fullname,
                Name=model.Name,
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                //ModelState.AddModelError("username", "XXXXX");
                //ModelState.AddModelError("", "YYYYY");

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("username", "Bu kullanıcı adı zaten kullanılıyor.");
                    ModelState.AddModelError("email", "Bu E-Mail zaten kullanılıyor.");
                    ModelState.AddModelError("passwordconfirm", "Şifreler uyuşmuyor");
                    //ModelState.AddModelError("", item.Description);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("username", "Kullanıcı adı ve/veya şifre yanlış");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("password", "Kullanıcı adı ve/veya şifre yanlış");
                ModelState.AddModelError("", "Kullanıcı adı ve/veya şifre yanlış");
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task Logout() => await _signInManager.SignOutAsync();
    }
}
