using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Models
{
    public class Flower
    {
        public int Id { get; set; }

        public string MainImage { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double? DiscountPrice { get; set; }
        public string Desc { get; set; }
        public string SKUCode { get; set; }
        public string Weight { get; set; }
        public string Deminsion { get; set; }
        public List<FlowerCategory> FlowerCategory { get; set; }
        public int? CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public int? TagId { get; set; }
        public Tag Tag { get; set; }
        public List<FlowerTag> FlowerTags { get; set; }

        public List<FlowerImage> FlowerImages { get; set; }






    }
}
