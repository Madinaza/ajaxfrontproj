using FrontProject.DAL;
using FrontProject.Models;
using FrontProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;


        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async  Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Sliders = await _context.Sliders.OrderBy(s => s.Order).ToListAsync(),
                Carousels =await _context.Carousels.Include(c=>c.Possition).Take(2).ToListAsync(),
                Categories= await _context.Categories.OrderByDescending(c=>c.Id).Take(6).ToListAsync(),
               Flowers= await _context.Flowers.Include(f=>f.FlowerCategory).ToListAsync()

            };
          
            return View(model);
        }
      
    }
    
}
