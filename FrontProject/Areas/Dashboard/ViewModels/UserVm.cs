using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontProject.Areas.Dashboard.ViewModels
{
    public class UserVm
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string  Roles{ get; set; }

        public string isActive { get; set; }

    }
}
