using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class BagMController : Controller
    {
        //
        // GET: /BagM/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var bagm1 = (from bag in db.BagM select bag).ToList();
            return View(bagm1);
        }

        //
        // GET: /BagM/Details/5

        public ActionResult Details(int id)
        {
            var bagmDetails = (from bag in db.BagM where bag.ID == id select bag).First();
            return View(bagmDetails);
        }

        //
        // GET: /BagM/Create

        public ActionResult Create()
        {
            BagM bm = new BagM();
            return View(bm);
        }

        //
        // POST: /BagM/Create

        [HttpPost]
        public ActionResult Create(BagM bm)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.BagM.Add(bm);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(String.Empty,ex);
            }
            return View(bm);
        }

        //
        // GET: /BagM/Edit/5

        public ActionResult Edit(int id)
        {
            var bagmEdit = (from bag in db.BagM where bag.ID == id select bag).First();
            return View(bagmEdit);
        }

        //
        // POST: /BagM/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var bagmEdit = (from bag in db.BagM where bag.ID == id select bag).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(bagmEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BagM/Delete/5

        public ActionResult Delete(int id)
        {
            var bagmDelete = (from bag in db.BagM where bag.ID == id select bag).First();
            return View(bagmDelete);
        }

        //
        // POST: /BagM/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var bagmDelete = (from bag in db.BagM where bag.ID == id select bag).First();
            try
            {
                // TODO: Add delete logic here
                db.BagM.Remove(bagmDelete);
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
