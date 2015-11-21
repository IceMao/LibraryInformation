using LibraryInformation.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInformation.Controllers
{
    public class HomeController:BaseController
    {
        [FromServices]
        public MemberContext DB { get; set; }

        public IActionResult Index()
        {
            var ret = DB.Members.ToList();
            return View(ret);
        }
    }
}
