using LibraryInformation.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInformation.Controllers
{
    public class AdminController : BaseController
    {
        [FromServices]
        public MemberContext DB { get; set; }
        
        [HttpGet]
        public IActionResult Details()
        {
            return PagedView(DB.Members, 10);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member Member)
        {
            DB.Members.Add(Member);
            DB.SaveChanges();
            return RedirectToAction("Details", "Admin");
        }

        [HttpPost]
        public IActionResult Edit(int id)
        {
            var member = DB.Members
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (member == null)
                return Content("没有找到记录");
            else
                return View(member);
        }
        
        [HttpPost]
        public IActionResult Edit(int id, Member member)
        {
            var s = DB.Members
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (s == null)
                return Content("没有找到记录");

            s.bookName = member.bookName;
            s.writer = member.writer;
            s.publishing = member.publishing;
            s.callNumber = member.callNumber;
            s.barCode = member.barCode;
            s.Note = member.Note;

            DB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var member = DB.Members
                .Where(x => x.Id == id)
                .SingleOrDefault();
            DB.Members.Remove(member);
            DB.SaveChanges();
            System.Diagnostics.Debug.Write("id=" + id);
            return RedirectToAction("Detail", "Admin");
        }
    }
}
