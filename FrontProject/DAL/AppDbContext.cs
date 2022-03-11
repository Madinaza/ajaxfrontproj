using FrontProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.DAL
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Possition> Possitions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Flower> Flowers { get; set; }

        public DbSet<FlowerCategory> FlowerCategories { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<FlowerImage> FlowerImages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<FlowerTag> FlowerTags { get; set; }

        public DbSet<Layout> Layouts { get; set; }

        public object AnyAsync { get; internal set; }
    }
}
