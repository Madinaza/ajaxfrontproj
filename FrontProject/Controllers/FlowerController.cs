using FrontProject.DAL;
using FrontProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Controllers
{
    public class FlowerController : Controller
    {
        private readonly AppDbContext _context;


        public FlowerController(AppDbContext context)
        {
            _context = context;
        }


       

        public async Task<IActionResult> Search(string searchStr)
        {
            if (string.IsNullOrWhiteSpace(searchStr))
            {
                return PartialView("_SearchPartialView", new List<Flower>());
            }
            var Flower = await _context.Flowers.Where(f => f.Name.ToUpper().Contains(searchStr.ToUpper())).ToListAsync();
                return PartialView("_SearchPartialView",Flower);
        }


        public async Task<IActionResult>Detail(int id,int categoryId)
        {
            Flower flower =  await _context.Flowers.Include(F => F.FlowerImages).Include(f => f.FlowerCategory).
                ThenInclude(fc => fc.Category).Include(f => f.FlowerTags).ThenInclude(fc => fc.Tag).Take(4).
                FirstOrDefaultAsync(f => f.Id == id);
   

            ViewBag.Related = _context.Flowers.
                Where(f =>
                    f.FlowerCategory.Select(f => f.CategoryId).Any(fc => flower.FlowerCategory.
                    Select(c => c.CategoryId).Contains(fc)) &&
                    f.Id != id)
                .Include(f => f.FlowerImages)
                .Include(f => f.FlowerCategory)
                .ThenInclude(fc => fc.Category)
                .ToList();
            return View(flower);



           
        }

    }
}
