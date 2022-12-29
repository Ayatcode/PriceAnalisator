using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) { return View(registerViewModel); }

            AppUser appUser = new()
            {
                Fullname = registerViewModel.Fullname,
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email,
                IsActive = true
            };
            var identityResult = await _userManager.CreateAsync(appUser, registerViewModel.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerViewModel);
            }
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) { return View(loginViewModel); }

            var user = await _userManager.FindByEmailAsync(loginViewModel.UsernameOrEmail);
            if (user == null)
            {
                user=await _userManager.FindByNameAsync(loginViewModel.UsernameOrEmail);
                if(user==null)
                {
                    ModelState.AddModelError("", "Username or passwor Incorrect");
                    return View(loginViewModel);
                }

            }
            var signInResult=await _signInManager.PasswordSignInAsync(user, loginViewModel.Password,loginViewModel.RememberMe,true);
            if (signInResult.IsLockedOut) 
            {
                ModelState.AddModelError("", "get gelersen");

            }
            if(!signInResult.Succeeded) 
            {
                ModelState.AddModelError("", "Username or passwor Incorrect");
                return View(loginViewModel);
            }
            if (!user.IsActive)
            {
                ModelState.AddModelError("", "Username or passwor Incorrect");
                return View(loginViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }
    }
    


    
}
