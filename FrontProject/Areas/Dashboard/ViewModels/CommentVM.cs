using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Areas.Dashboard.ViewModels
{
    public class CommentVM
    {
            [Required, MaxLength(800), MinLength(10)]
            public string Description { get; set; }
        
    }
}
