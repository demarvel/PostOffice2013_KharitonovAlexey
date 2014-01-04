using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class PackingController : Controller
    {
        //
        // GET: /Packing/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var Packing = (from pk in db.Packing select pk).ToList();
            return View(Packing);
        }

        //
        // GET: /Packing/Details/5

        public ActionResult Details(int id)
        {
            var PackingDetails = (from pk in db.Packing where pk.ID == id select pk).First();
            return View(PackingDetails);
        }

        //
        // GET: /Packing/Create

        public ActionResult Create()
        {
            Packing pk = new Packing();
            return View(pk);
        }

        //
        // POST: /Packing/Create

        [HttpPost]
        public ActionResult Create(Packing pk)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Packing.Add(pk);
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
        // GET: /Packing/Edit/5

        public ActionResult Edit(int id)
        {
            var PackingEdit = (from pk in db.Packing where pk.ID == id select pk).First();
            return View(PackingEdit);
        }

        //
        // POST: /Packing/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var PackingEdit = (from pk in db.Packing where pk.ID == id select pk).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(PackingEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Packing/Delete/5

        public ActionResult Delete(int id)
        {
            var PackingDelete = (from pk in db.Packing where pk.ID == id select pk).First();
            return View(PackingDelete);
        }

        //
        // POST: /Packing/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var PackingDelete = (from pk in db.Packing where pk.ID == id select pk).First();
            try
            {
                // TODO: Add delete logic here
                db.Packing.Remove(PackingDelete);
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
