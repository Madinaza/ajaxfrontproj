using FrontProject.DAL;
using FrontProject.Models;
using FrontProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.ViewComponents
{
    public class NavViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;


        public NavViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Layout layout =await _context.Layouts.FirstOrDefaultAsync();
            var basketJson = Request.Cookies["basket"];
            var basket = JsonConvert.DeserializeObject<List<BasketVM>>(basketJson);
            ViewBag.Count = basket.Sum(b => b.Count);
            ViewBag.TotalPrice = basket.Sum(t => t.Flower.Price * t.Count);



            return View(new NavVM {Layout=layout,Basket=basket});
        }

    }
}
