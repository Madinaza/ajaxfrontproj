using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Areas.Dashboard.ViewModels
{
    public class CreateMultiple
    {
        public string Title { get; set; }

        public string Desc { get; set; }

        [NotMapped]
        [Required]
        public IFormFile SignatureImageFile { get; set; }

        public IFormFile [] Images { get; set; }
    }

}
