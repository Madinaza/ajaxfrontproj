using FrontProject.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FrontProject.Areas.Dashboard.ViewModels
{
    public class FlowerPostVM
    {
        public IFormFile MainImage { get; set; }
        public IFormFile[] Images { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
   
        public string Desc { get; set; }
        public string SKUCode { get; set; }
        public string Weight { get; set; }
        public string Deminsion { get; set; }

        public int? CampaignId { get; set; }
        public List<int> CategoryId { get; set; }


        public List<Category> Categories { get; set; }
        public List<Campaign> Campaigns { get; set; }

    }
}
