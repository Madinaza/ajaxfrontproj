using FrontProject.DAL;
using FrontProject.Models;
using FrontProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddToBasket(int Id)
        {
            Flower flower = await _context.Flowers.FindAsync(Id);
            if (flower == null) return RedirectToAction("Index","Home");

            List<BasketVM> basket;

            var basketJson = Request.Cookies["basket"];
            if (string.IsNullOrEmpty(basketJson))
            {
                basket = new List<BasketVM>();
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(basketJson);
            }

            var existFlower = basket.Find(b => b.Flower.Id==Id);
            if (existFlower == null)
            {
                basket.Add(new BasketVM { Flower = flower });
            }
            else
            {
                existFlower.Count++;

            }


            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            return RedirectToAction("Index", "Home");
        }

        public async  Task<IActionResult> Getbasket()
        {
            var basketJson = Request.Cookies["basket"];
            List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(basketJson);
            List<BasketVM> newBasket = new List<BasketVM>();
            foreach (var item in basket)
            {
                Flower flower = await _context.Flowers.FindAsync(item.Flower.Id);
                if (flower == null)
                {
                    continue;
                }

                newBasket.Add(new BasketVM { Flower = flower, Count = item.Count });
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            
            return Content(JsonConvert.SerializeObject(basket));
        }
    }
}
