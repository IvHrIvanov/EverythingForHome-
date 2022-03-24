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
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var registerAccount = new Account()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
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

    }
}
