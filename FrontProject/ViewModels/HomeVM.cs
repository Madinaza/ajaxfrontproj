using FrontProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.ViewModels
{
    public class HomeVM
    {
        public List<Carousel>Carousels{ get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Carousel> Carousel { get; internal set; }

        public List<Category> Categories { get; set; }
        public List<Flower> Flowers { get; set; }
    }

}
