using FrontProject.DAL;
using FrontProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Areas.Dashboard.Controllers
{

    [Area("Dashboard")]
    public class SliderController : Controller
    {
       
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async  Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            if (!slider.ImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(slider.ImageFile), "File type is unsupported");
                return View();
            }

            if (!ModelState.IsValid) return View();
            if (!slider.SignatureImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(slider.SignatureImageFile), "File type is unsupported");
                return View();
            }
            var fileName = Guid.NewGuid()+ slider.ImageFile.FileName;
            string wwwRootPath = _env.WebRootPath;
            var fullPath = Path.Combine(wwwRootPath, "assets", "images", fileName);


            FileStream stream = new FileStream(fullPath, FileMode.Create);
            await slider.ImageFile.CopyToAsync(stream);
            stream.Close();

            var fileName1 = Guid.NewGuid() + slider.SignatureImageFile.FileName;
            string wwwRootPath1 = _env.WebRootPath;
            var fullPath1 = Path.Combine(wwwRootPath1, "assets", "images", fileName1);


            FileStream stream1 = new FileStream(fullPath1, FileMode.Create);
            await slider.SignatureImageFile.CopyToAsync(stream1);
            stream.Close();

            slider.Image = fileName;
            slider.SignatureImage = fileName1;

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
