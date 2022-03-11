using FrontProject.Areas.Constants;
using FrontProject.Models;
using FrontProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = RoleConstant.Admin)]

    public class AccountController : Controller
    {


        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;


        public AccountController(UserManager<User> userManager, SignInManager<User> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        public IActionResult Login()
        {
            return View();
        }

       [HttpPost]
       [ValidateAntiForgeryToken]

       public async Task<IActionResult>Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(model.Login);
            if (user == null) user = await _userManager.FindByEmailAsync(model.Login);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View();
            }
         
            
            var signinResult = await _signManager.PasswordSignInAsync(user, model.Password,true, false);
            if (!signinResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View();
            };
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }







        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVm model)
        {
            
           if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                ModelState.AddModelError("UserName", "this is exist");
                return View();
            }
            User nUser = new User
            {
                FullName = model.Fullname,
                UserName = model.UserName,
                Age = model.Age,
                Email = model.Email,
                Possition = model.Possition
            };
            IdentityResult identityResult = await _userManager.CreateAsync(nUser, model.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(nUser, RoleConstant.Users);

            await _signManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");

            
        }
    }
}
