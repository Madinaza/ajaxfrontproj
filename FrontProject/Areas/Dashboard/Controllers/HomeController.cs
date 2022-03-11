using FrontProject.Areas.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    //[Authorize(Roles = RoleConstant.Admin)]
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
