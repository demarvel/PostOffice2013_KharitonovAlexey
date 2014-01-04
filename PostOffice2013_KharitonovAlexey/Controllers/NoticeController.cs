using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class NoticeController : Controller
    {
        //
        // GET: /Notice/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var Notice = (from nt in db.Notice select nt).ToList();
            return View(Notice);
        }

        //
        // GET: /Notice/Details/5

        public ActionResult Details(int id)
        {
            var NoticeDetails = (from nt in db.Notice where nt.ID == id select nt).First();
            return View(NoticeDetails);
        }

        //
        // GET: /Notice/Create

        public ActionResult Create()
        {
            Notice nt = new Notice();
            return View(nt);
        }

        //
        // POST: /Notice/Create

        [HttpPost]
        public ActionResult Create(Notice nt)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Notice.Add(nt);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(String.Empty,ex);
            }
            return View();
        }

        //
        // GET: /Notice/Edit/5

        public ActionResult Edit(int id)
        {
            var NoticeEdit = (from nt in db.Notice where nt.ID == id select nt).First();
            return View(NoticeEdit);
        }

        //
        // POST: /Notice/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var NoticeEdit = (from nt in db.Notice where nt.ID == id select nt).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(NoticeEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Notice/Delete/5

        public ActionResult Delete(int id)
        {
            var NoticeDelete = (from nt in db.Notice where nt.ID == id select nt).First();
            return View(NoticeDelete);
        }

        //
        // POST: /Notice/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var NoticeDelete = (from nt in db.Notice where nt.ID == id select nt).First();
            try
            {
                // TODO: Add delete logic here
                db.Notice.Remove(NoticeDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
