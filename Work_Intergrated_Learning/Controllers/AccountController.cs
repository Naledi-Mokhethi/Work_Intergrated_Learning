using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Models;

namespace Work_Intergrated_Learning.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //GET /account/register
        public IActionResult Register() => View();

        //POST /account/register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.UserName,
                    Surname = user.Surname,
                    PhoneNumber = user.PhoneNumber,
                    Number = user.Number,
                    Department = user.Department,
                    YearOfStudy = user.YearOfStudy,
                    CV = user.CV,
                    AcademicRecord = user.AcademicRecord,
                    Email = user.Email

                };
                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }

            return View(user);
        }

        //GET /account/login
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login
            {
                ReturnUrl = returnUrl
            };
            return View(login);
        }

        //POST /account/login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(login.Email);
                {
                    if(appUser != null)
                    {
                        Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                        if(result.Succeeded)
                        {
                            return Redirect(login.ReturnUrl ?? "/");
                        }
                    }
                    ModelState.AddModelError("", "Login Failed, Incorrect Credentials");
                }
            }

            return View(login);
        }

        //GET /account/logout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

        //GET /account/edit
        public async Task<IActionResult> Edit()
        {
            AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);
            User user = new User(appUser);
            return View(user);

        }
        //Before Moving on continue @6:55:41
    }

}
