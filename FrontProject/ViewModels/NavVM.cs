using FrontProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.ViewModels
{
    public class NavVM
    {
        public Layout Layout { get; set; }
        public List<BasketVM>Basket{ get; set; }
    }
}
