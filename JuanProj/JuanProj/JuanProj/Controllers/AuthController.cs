using Core.Entities;
using JuanProj.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static JuanProj.Utilities.Helper;

namespace JuanProj.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            await _userManager.AddToRoleAsync(appUser, RoleType.Member.ToString());
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
                user = await _userManager.FindByNameAsync(loginViewModel.UsernameOrEmail);
                if (user == null)
                {
                    ModelState.AddModelError("", "Username or passwor Incorrect");
                    return View(loginViewModel);
                }

            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "get gelersen");

            }
            if (!signInResult.Succeeded)
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
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) { ModelState.AddModelError("Email", "Email not found"); return View(model); }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string? link = Url.Action("ResetPassword", "Auth", new { userId = user.Id, token = token }, HttpContext.Request.Scheme);

            return Json(link);
        }


        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token)) { return BadRequest(); }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) { return NotFound(); }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model, string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token)) { return BadRequest(); }
            if (!ModelState.IsValid) { return View(model); }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) { return NotFound(); }

            var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);


                }
                return View();
            }
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> CreateRoles()
        {
            foreach (var role in Enum.GetValues(typeof(RoleType)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role.ToString()));
                }
            }
            return RedirectToAction("Index", "Home");
        }
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
