using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Models;

namespace ProjectEverything.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Account> userMenager;
        private readonly SignInManager<Account> signInManager;

        public UserController(UserManager<Account> userMenager, SignInManager<Account> signInManager)
        {
            this.userMenager = userMenager;
            this.signInManager = signInManager;
         
        }

        public IActionResult Register() => View();
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var registerAccount = new Account()
            {
                UserName = user.Email,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Town = user.Town,
                Address = user.Address,
            };
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
        public async Task<IActionResult> Logout(LoginFormModel user)
        {
            
            await signInManager.SignOutAsync();
          
            return RedirectToAction("Index", "Home");
        }
    }

}
