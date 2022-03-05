using FrontProject.Areas.Constants;
using FrontProject.Areas.Dashboard.ViewModels;
using FrontProject.Areas.Extensions;
using FrontProject.Areas.Utils;
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
            if (!slider.ImageFile.IsSupported("image"))
            {
                ModelState.AddModelError(nameof(slider.ImageFile), "File type is unsupported");
                return View();
            }

            if (!ModelState.IsValid) return View();
            if (!slider.SignatureImageFile.IsSupported("image"))
            {
                ModelState.AddModelError(nameof(slider.SignatureImageFile), "File type is unsupported");
                return View();
            }
           
        

            slider.Image = Utils.Fileutils.Create(Fileconstants.ImagePath,slider.ImageFile);
            slider.SignatureImage = Utils.Fileutils.Create(Fileconstants.SignaturEImagePath, slider.ImageFile);

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            Fileutils.Delete(Path.Combine(Fileconstants.ImagePath, slider.SignatureImage));
            Fileutils.Delete(Path.Combine(Fileconstants.ImagePath, slider.Image));
            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }

        public IActionResult CreateMultiple()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiple(CreateMultiple model)
        {
            if (!ModelState.IsValid) return View();

            foreach (var image in model.Images)
            {
                Slider slider = new Slider
                {
                    Title = model.Title,
                    Desc = model.Desc,
                    SignatureImage = Fileutils.Create(Fileconstants.ImagePath, model.SignatureImageFile),
                    Image = Fileutils.Create(Fileconstants.ImagePath, image),
                    Order = 1

                };
                await _context.Sliders.AddAsync(slider);
            };
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

          
        }

    }
}
