using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class PrandController : Controller
    {
        //
        // GET: /Prand/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var Brand = (from br in db.Brand select br).ToList();
            return View(Brand);
        }

        //
        // GET: /Prand/Details/5

        public ActionResult Details(int id)
        {
            var BrandDetails = (from br in db.Brand where br.ID == id select br).First();
            return View(BrandDetails);
        }

        //
        // GET: /Prand/Create

        public ActionResult Create()
        {
            Brand br = new Brand();
            return View(br);
        }

        //
        // POST: /Prand/Create

        [HttpPost]
        public ActionResult Create(Brand br)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Brand.Add(br);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View();
        }

        //
        // GET: /Prand/Edit/5

        public ActionResult Edit(int id)
        {
            var BrandEdit = (from br in db.Brand where br.ID == id select br).First();
            return View(BrandEdit);
        }

        //
        // POST: /Prand/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var BrandEdit = (from br in db.Brand where br.ID == id select br).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(BrandEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Prand/Delete/5

        public ActionResult Delete(int id)
        {
            var BrandDelete = (from br in db.Brand where br.ID == id select br).First();
            return View(BrandDelete);
        }

        //
        // POST: /Prand/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var BrandDelete = (from br in db.Brand where br.ID == id select br).First();
            try
            {
                // TODO: Add delete logic here
                db.Brand.Remove(BrandDelete);
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
