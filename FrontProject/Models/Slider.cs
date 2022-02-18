using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:500)]
        public string Image { get; set; }
        public string Desc { get; set; }
        public string Title { get; set; }

        public string SignatureImage { get; set; }

        public int Order { get; set; }

    }
}
