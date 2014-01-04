using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class BanderollController : Controller
    {
        //
        // GET: /Banderoll/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var Banderol = (from band in db.Banderoll select band).ToList();
            return View(Banderol);
        }

        //
        // GET: /Banderoll/Details/5

        public ActionResult Details(int id)
        {
            var BanderolDetails = (from band in db.Banderoll where band.ID == id select band).First();
            return View(BanderolDetails);
        }

        //
        // GET: /Banderoll/Create

        public ActionResult Create()
        {
            Banderoll band = new Banderoll();
            return View(band);
        }

        //
        // POST: /Banderoll/Create

        [HttpPost]
        public ActionResult Create(Banderoll band)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Banderoll.Add(band);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View();
        }

        //
        // GET: /Banderoll/Edit/5

        public ActionResult Edit(int id)
        {
            var BanderolEdit = (from band in db.Banderoll where band.ID == id select band).First();
            return View(BanderolEdit);
        }

        //
        // POST: /Banderoll/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var BanderolEdit = (from band in db.Banderoll where band.ID == id select band).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(BanderolEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Banderoll/Delete/5

        public ActionResult Delete(int id)
        {
            var BanderolDelete = (from band in db.Banderoll where band.ID == id select band).First();
            return View(BanderolDelete);
        }

        //
        // POST: /Banderoll/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var BanderolDelete = (from band in db.Banderoll where band.ID == id select band).First();
            try
            {
                // TODO: Add delete logic here
                db.Banderoll.Remove(BanderolDelete);
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
