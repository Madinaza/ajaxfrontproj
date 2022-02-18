using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Models
{
    public class Possition
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public List<Carousel>Carousels { get; set; }
    }
}
