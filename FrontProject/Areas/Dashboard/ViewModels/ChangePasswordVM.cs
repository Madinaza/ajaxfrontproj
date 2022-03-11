using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Areas.Dashboard.ViewModels
{
    public class ChangePasswordVM
    {
        [Required,DataType(DataType.Password)]
        
        public string OldPassword { get; set; }
        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password),Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }


    }
}
