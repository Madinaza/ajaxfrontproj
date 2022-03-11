using FrontProject.Areas.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.DAL
{
    public class DataInitializer
    {
        private readonly AppDbContext _appdbContext;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public DataInitializer(AppDbContext appdbContex, RoleManager<IdentityRole> rolemanager)
        {
            _appdbContext = appdbContex;
            _rolemanager = rolemanager;
        }
        public async Task SeedData()
        {
            if (!_appdbContext.Roles.Any())
            {
                await _rolemanager.CreateAsync(new IdentityRole(RoleConstant.Admin));
                await _rolemanager.CreateAsync(new IdentityRole(RoleConstant.Moderator));
                await _rolemanager.CreateAsync(new IdentityRole(RoleConstant.Users));


            }
        }

        internal Task SeedDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
