using FrontProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.ViewComponents
{
    public class FlowerViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;


        public FlowerViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var related =await _context.Flowers.Include(f => f.FlowerCategory).ThenInclude(fc=>fc.Category).ToListAsync();
            return View(related);
        }
    }
}
