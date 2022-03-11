using FrontProject.Areas.Constants;
using FrontProject.Areas.Dashboard.ViewModels;
using FrontProject.DAL;
using FrontProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    //[Authorize(Roles =RoleConstant.Admin+","+RoleConstant.Moderator)]


    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(AppDbContext dbContext,UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var userS = await _dbContext.Users.ToListAsync();
            List<UserVm> userlist = new List<UserVm>();
            foreach (var user in userS )
            {
                userlist.Add(new UserVm
                {
                    Id = user.Id,
                    Fullname=user.FullName,
                    Username=user.UserName,
                    Roles=string.Join(",",(await _userManager.GetRolesAsync(user)))

                }) ;
            }
            return View(userlist);
        }


        public async Task<IActionResult> GetRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.Name = user.FullName;
            ViewBag.id = user.Id;
            return View(roles);
        }

        public async Task<IActionResult>RemoveRole(string id,string roleName)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await _userManager.RemoveFromRoleAsync(user, roleName);

            return RedirectToAction(nameof(GetRoles), new { user.Id });

        }

        public async Task<IActionResult> AddRole(string id)
        {
            var roles = await _dbContext.Roles.Select(r => r.Name).ToListAsync();

            AddRoleVM model = new AddRoleVM
            {
                UserId = id,
                Roles = roles
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>AddRole(string id,AddRoleVM model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!ModelState.IsValid) return View();

            await _userManager.AddToRoleAsync(user, model.RoleName);
            return RedirectToAction(nameof(Index), new { id });

        }

        public async Task<IActionResult>ChangePassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            ViewBag.FullName = user.FullName;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>ChangePassword(string id ,ChangePasswordVM model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (!await _userManager.CheckPasswordAsync(user, model.OldPassword))
            {
                ModelState.AddModelError(nameof(ChangePasswordVM.OldPassword), "Old password is not correct");
                return View();
            }
            var IdResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!IdResult.Succeeded)
            {
                foreach (var eror in IdResult.Errors )
                {
                    ModelState.AddModelError("", eror.Description);
                }
                return View();
            }

            return RedirectToAction(nameof(Index));


        }
        //public async Task<IActionResult>Block(string id, UserVm model)
        //{
        //    var user = await _userManager.FindByIdAsync(id);
        //    if (user == null) return NotFound();
        //    if (!ModelState.IsValid) return View();


        //    IdentityResult isActive = await _userManager.CreateAsync(user, model.isActive);
        //    if (!isActive.Succeeded)
        //    {
        //        foreach (var error in isActive.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //        return View();
        //    }
        //}
        

        

    }

   




}
