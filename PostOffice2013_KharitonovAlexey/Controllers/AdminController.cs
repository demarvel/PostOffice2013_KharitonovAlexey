using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            var worcers1 = (from worcers in db.Worker select worcers).ToList();
            return View(worcers1);
        }

        //
        // GET: /Admin/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var worcersdetails = (from worcers in db.Worker where worcers.ID == id select worcers).First();
            return View(worcersdetails);
        }

        //
        // GET: /Admin/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            Worker wr = new Worker();
            return View(wr);
        }

        //
        // POST: /Admin/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Worker wr)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Worker.Add(wr);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(wr);
        }

        //
        // GET: /Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var worcersedit = (from worcers in db.Worker where worcers.ID == id select worcers).First();
            return View(worcersedit);
        }

        //
        // POST: /Admin/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var worcersedit = (from worcers in db.Worker where worcers.ID == id select worcers).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(worcersedit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(worcersedit);
            }
        }

        //
        // GET: /Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var worcersdelete = (from worcers in db.Worker where worcers.ID == id select worcers).First();
            return View(worcersdelete);
        }

        //
        // POST: /Admin/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var worcersdelete = (from worcers in db.Worker where worcers.ID == id select worcers).First();
            try
            {
                // TODO: Add delete logic here
                db.Worker.Remove(worcersdelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(worcersdelete);
            }
        }
    }
}
