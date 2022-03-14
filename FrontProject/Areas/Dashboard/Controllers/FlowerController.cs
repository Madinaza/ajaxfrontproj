using FrontProject.Areas.Constants;
using FrontProject.Areas.Dashboard.ViewModels;
using FrontProject.Areas.Extensions;
using FrontProject.Areas.Utils;
using FrontProject.DAL;
using FrontProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    //[Authorize(Roles = RoleConstant.Admin + "," + RoleConstant.Moderator)]
    public class FlowerController : Controller
    {
        private readonly AppDbContext _context;


        public FlowerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var flowers = await _context.Flowers.Select(f => new FlowerListVm
            {
                id = f.Id,
                Name = f.Name,
                Price = f.Price,
                MainImage = f.MainImage,
            }).ToListAsync();
            return View(flowers);
        }


        public async Task< IActionResult> Deteil(int id)
        {

            var flower = await _context.Flowers.Include(f => f.FlowerImages)
                  .Include(f => f.FlowerCategory)
                  .ThenInclude(fc => fc.Category).FirstOrDefaultAsync(f => f.Id == id);

            if (flower == null) return NotFound();

            return View(flower);
        }













        public async Task<IActionResult> Create()
        {
            FlowerPostVM flowerPostVM = new FlowerPostVM
            {
                Campaigns = await _context.Campaigns.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),

            };
            return View(flowerPostVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlowerPostVM model)
        {
            model.Campaigns = await _context.Campaigns.ToListAsync();
            model.Categories = await _context.Categories.ToListAsync();
            if (!ModelState.IsValid) return View(model);
            var campaign = await _context.Campaigns.FindAsync(model.CampaignId);
            if (campaign == null)
            {
                ModelState.AddModelError(nameof(FlowerPostVM.CampaignId), "Choose a valid campaign");
            }
            foreach (var categorid in model.CategoryId)
            {
                var category = await _context.Categories.FindAsync(categorid);
                if (category == null)
                {
                    ModelState.AddModelError(nameof(FlowerPostVM.CategoryId), "Choose a valid categories");
                    return View();
                }
            }
            if (!model.MainImage.IsSupported("image"))
            {
                ModelState.AddModelError(nameof(model.MainImage), "File type is unsupported");
                return View(model);
            }

            if (!ModelState.IsValid) return View();
            if (!model.MainImage.IsSupported("image"))
            {
                ModelState.AddModelError(nameof(model.MainImage), "File type is unsupported");
                return View(model);
            }


            Flower flower = new Flower
            {
                Name = model.Name,
                Price = model.Price,
                Deminsion = model.Deminsion,
                Weight = model.Weight,
                Desc = model.Desc,
                CampaignId = model.CampaignId,
                MainImage = Fileutils.Create(Fileconstants.ImagePath, model.MainImage),
                
            };
            await _context.Flowers.AddAsync(flower);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Delete(int id)
        {
            var flower = await _context.Flowers.Include(F => F.FlowerImages).Include(f => f.FlowerCategory).
                ThenInclude(fc => fc.Category).
                FirstOrDefaultAsync(f => f.Id == id);
           if(flower==null)return NotFound();
           return View(flower); 

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteFlower(int id)
        {
            var flower = await _context.Flowers.Include(F => F.FlowerImages).Include(f => f.FlowerCategory).
                  ThenInclude(fc => fc.Category).
                  FirstOrDefaultAsync(f => f.Id == id);
            if (flower == null) return NotFound();
            List<FlowerCategory> categories = new List<FlowerCategory>();

            foreach (var image in flower.FlowerImages)
            {
                Fileutils.Delete(Path.Combine(Fileconstants.ImagePath, image.Name));
            }

            Fileutils.Delete(Path.Combine(Fileconstants.ImagePath, flower.MainImage));
            _context.Remove(flower);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));   

        }


        public async Task<IActionResult> Update(int id)
        {
            var flower = await _context.Flowers.Include(F => F.FlowerImages).Include(f => f.FlowerCategory).
                 ThenInclude(fc => fc.Category).
                 FirstOrDefaultAsync(f => f.Id == id);
            if (flower == null) return NotFound();

            FlowerPostVM model = new FlowerPostVM
            {
                CategoryId=flower.FlowerCategory.Select(c => c.Category.Id).ToList(),
                Name=flower.Name,
                Desc=flower.Desc,   
                Price=flower.Price,
                SKUCode=flower.SKUCode,
                Weight=flower.Weight,
                Deminsion=flower.Deminsion,
                CampaignId=flower.CampaignId,
                Categories=await _context.Categories.ToListAsync(),
                Campaigns=await _context.Campaigns.ToListAsync(),
            };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Update(int id,FlowerPostVM model)
        {
            var flower = await _context.Flowers.Include(F => F.FlowerImages).Include(f => f.FlowerCategory).
                    ThenInclude(fc => fc.Category).
                    FirstOrDefaultAsync(f => f.Id == id);
            if (flower == null) return NotFound();
            model.Campaigns = await _context.Campaigns.ToListAsync();
            model.Categories = await _context.Categories.ToListAsync();
            if (!ModelState.IsValid) return View(model);

            var campaign = await _context.Campaigns.FindAsync(model.CampaignId);
            if (campaign == null)
            {
                ModelState.AddModelError(nameof(FlowerPostVM.CampaignId), "Choose a valid campaign");
            };
            List<FlowerCategory> categories = new List<FlowerCategory>();
            foreach (var categorid in model.CategoryId)
            {
                var category = await _context.Categories.FindAsync(categorid);
                if (category == null)
                {
                    ModelState.AddModelError(nameof(FlowerPostVM.CategoryId), "Choose a valid categories");
                    return View();
                }
            }

            if (model.MainImage != null)
            {
                if (!model.MainImage.IsSupported("image"))
                {
                    ModelState.AddModelError(nameof(FlowerPostVM.MainImage), "File type is unsupported");
                    return View(model);
                }
                Fileutils.Delete(Path.Combine(Fileconstants.ImagePath, flower.MainImage));
            }
            List<FlowerImage> images = null;
            if (model.Images != null)
            {
                images = new List<FlowerImage>(); 
                foreach (var image in model.Images)
                {
                    if (!image.IsSupported("image"))
                    {
                        ModelState.AddModelError(nameof(FlowerPostVM.Images), "File type is unsupported");
                        return View(model);
                    }
                    images.Add(new FlowerImage { FlowerId = flower.Id, Name = Fileutils.Create(Fileconstants.ImagePath,image) });

                }
                foreach (var image in flower.FlowerImages)
                {
                    Fileutils.Delete(Path.Combine(Fileconstants.ImagePath, image.Name));

                }
            }
            flower.Name=model.Name;
            flower.Desc=  model.Desc;
            flower.Price= model.Price;
            flower.Weight= model.Weight;    
            flower.SKUCode= model.SKUCode;
            flower.FlowerCategory = categories;
            flower.FlowerImages = images.Count>0 ?images:flower.FlowerImages;  
            flower.MainImage = model.MainImage!=null?Fileutils.Create(Fileconstants.ImagePath,model.MainImage):flower.MainImage;


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));   

        }











    }



}
