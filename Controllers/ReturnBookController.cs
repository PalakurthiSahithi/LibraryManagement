using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class ReturnBookController : Controller
    {

        libraryEntities1 db = new libraryEntities1();

        // GET: ReturnBook
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(ReturnBook returns)
        {

            if (ModelState.IsValid)
            {
                db.ReturnBooks.Add(returns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(returns);
        }

        public ActionResult GetMid(int mid)
        {
            var memberid = (from s in db.IssueBooks
                            where s.m_id == mid
                            select new
                            {
                                IssueDate = s.issuedate,
                                ReturnDate = s.returndate,
                                Memberid = s.m_id,
                                BookName = s.book_id,
                                ElapsDays = SqlFunctions.DateDiff("day",s.returndate,DateTime.Now)
                            }).ToArray();

            return Json(memberid, JsonRequestBehavior.AllowGet);
        }
    }
   
}