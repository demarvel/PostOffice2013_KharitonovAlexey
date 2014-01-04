using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class PensionerController : Controller
    {
        //
        // GET: /Pensioner/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var Pensioner = (from pn in db.Pensioner select pn).ToList();
            return View(Pensioner);
        }

        //
        // GET: /Pensioner/Details/5

        public ActionResult Details(int id)
        {
            var PensionerDetails = (from pn in db.Pensioner where pn.ID == id select pn).First();
            return View(PensionerDetails);
        }

        //
        // GET: /Pensioner/Create

        public ActionResult Create()
        {
            Pensioner pn = new Pensioner();
            return View(pn);
        }

        //
        // POST: /Pensioner/Create

        [HttpPost]
        public ActionResult Create(Pensioner pn)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Pensioner.Add(pn);
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
        // GET: /Pensioner/Edit/5

        public ActionResult Edit(int id)
        {
            var PensionerEdit = (from pn in db.Pensioner where pn.ID == id select pn).First();
            return View(PensionerEdit);
        }

        //
        // POST: /Pensioner/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var PensionerEdit = (from pn in db.Pensioner where pn.ID == id select pn).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(PensionerEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pensioner/Delete/5

        public ActionResult Delete(int id)
        {
            var PensionerDelete = (from pn in db.Pensioner where pn.ID == id select pn).First();
            return View(PensionerDelete);
        }

        //
        // POST: /Pensioner/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var PensionerDelete = (from pn in db.Pensioner where pn.ID == id select pn).First();
            try
            {
                // TODO: Add delete logic here
                db.Pensioner.Remove(PensionerDelete);
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
