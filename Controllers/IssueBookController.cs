using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class IssueBookController : Controller
    {
        libraryEntities1 db = new libraryEntities1();
        // GET: IssueBook
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBook()
        {
            var books = db.Books.Select(p => new
            {
                ID = p.id,
                Bname = p.bname

            }).ToList();

            return Json(books, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetMid(int mid)
        {
            var memberid = (from s in db.Members where s.id == mid select s.name).ToList();

            return Json(memberid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(IssueBook issue)
        {
            if(ModelState.IsValid)
            { 
                db.IssueBooks.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(issue);
        }
    }
}