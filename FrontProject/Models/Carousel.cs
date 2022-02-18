using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Models
{
    public class Carousel
    {
        public int Id{ get; set; }

        public string Fullname { get; set; }
        public string Image { get; set; }
        public int PossitionId { get; set; }

        public string Desc { get; set; }

        public Possition Possition { get; set; }

    }
}
