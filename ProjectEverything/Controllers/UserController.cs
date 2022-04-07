using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Models;
using ProjectEverything.Service.Users;

namespace ProjectEverything.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Account> userMenager;
        private readonly SignInManager<Account> signInManager;
        private readonly IAccountService accountService;
        public UserController(UserManager<Account> userMenager, SignInManager<Account> signInManager, IAccountService accountService)
        {
            this.userMenager = userMenager;
            this.signInManager = signInManager;
            this.accountService = accountService;
        }

        public IActionResult Register() => View();
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var registerAccount = accountService.CraeateAccount(user);
            var result = await this.userMenager.CreateAsync(registerAccount, user.Password);
            if (!result.Succeeded)
            {
                var erros = result.Errors.Select(e => e.Description);
                foreach (var error in erros)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel user)
        {
            const string invalidCredentials = "Credentials invalid.";

            var loggedUser = await this.userMenager.FindByEmailAsync(user.Email);
            if (loggedUser == null)
            {
                ModelState.AddModelError(string.Empty, invalidCredentials);
                return View(user);
            }
            var passwordIsValid = await this.userMenager.CheckPasswordAsync(loggedUser, user.Password);
            if (!passwordIsValid)
            {
                ModelState.AddModelError(string.Empty, invalidCredentials);
                return View(user);
            }
            await this.signInManager.SignInAsync(loggedUser, true);
            return RedirectToAction("Index", "Home");
        } 
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
          
            return RedirectToAction("Index", "Home");
        }

    }

}
