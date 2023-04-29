using BookStore.WebApp.Data.Entities.Identities;
using BookStore.WebApp.Models.Identies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ILogger<HomeController> _logger;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public IActionResult Welcome() => View();
        public IActionResult Index() => View();
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    var result = await _signInManager.PasswordSignInAsync(user,
                        model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index","Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "kullanıcı bulunamadı");
            }
            else
                ModelState.AddModelError(string.Empty, "hata");
            return View(model);
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Username, Email = model.EMail };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                result.Errors.ToList()
                       .ForEach(
                           f => ModelState.AddModelError(string.Empty, f.Description)
                       );
            }
            return View(model);
        }

        public async Task Logout() => await _signInManager.SignOutAsync();
    }
}
