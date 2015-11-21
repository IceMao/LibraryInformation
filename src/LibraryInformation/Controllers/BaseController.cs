using LibraryInformation.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInformation.Controllers
{
    public class BaseController : BaseController<MemberContext, User, string>
    {
    }
}
