using FrontProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.ViewModels
{
    public class BasketVM
    {
        public int Count { get; set; } = 1;
        public Flower Flower { get; set; }
    }
}
