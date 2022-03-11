using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.ViewModels
{
    public class LoginViewModel
    {
        [Required, MaxLength(30)]
        public string Login { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
       
    }
}
