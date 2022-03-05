using FrontProject.DAL;
using FrontProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class LayoutController : Controller
    {
        private readonly AppDbContext _context;

        public LayoutController(AppDbContext context)
        {
            _context = context;
        }
        public async  Task<IActionResult> Index()
        {
            List<Layout> layouts = await _context.Layouts.ToListAsync();
            return View(layouts);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Layout layout)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.Layouts.AddAsync(layout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Layout layout = await _context.Layouts.FindAsync(id);
            if (layout == null) return NotFound();
            return View(layout);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Layout layout)
        {
            bool IsExsist = await _context.Layouts.AnyAsync(l => l.Id == id);
            if (!IsExsist) return NotFound();
            if (!ModelState.IsValid) return View();

            _context.Layouts.Update(layout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            Layout layout = await _context.Layouts.FindAsync(id);
            if (layout == null) return NotFound();
            return View(layout);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteLayout(int id)
        {
            Layout layout = await _context.Layouts.FindAsync(id);
            if (layout == null) return NotFound();
            if (!ModelState.IsValid) return View();
            _context.Layouts.Remove(layout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
