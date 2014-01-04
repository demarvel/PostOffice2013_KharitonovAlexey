using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class SecogrammaController : Controller
    {
        //
        // GET: /Secogramma/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var Secogramma = (from sc in db.Secogramma select sc).ToList();
            return View(Secogramma);
        }

        //
        // GET: /Secogramma/Details/5

        public ActionResult Details(int id)
        {
            var SecogrammaDetails = (from sc in db.Secogramma where sc.ID == id select sc).First();
            return View(SecogrammaDetails);
        }

        //
        // GET: /Secogramma/Create

        public ActionResult Create()
        {
            Secogramma sc = new Secogramma();
            return View(sc);
        }

        //
        // POST: /Secogramma/Create

        [HttpPost]
        public ActionResult Create(Secogramma sc)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Secogramma.Add(sc);
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
        // GET: /Secogramma/Edit/5

        public ActionResult Edit(int id)
        {
            var SecogrammaEdit = (from sc in db.Secogramma where sc.ID == id select sc).First();
            return View(SecogrammaEdit);
        }

        //
        // POST: /Secogramma/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var SecogrammaEdit = (from sc in db.Secogramma where sc.ID == id select sc).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(SecogrammaEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Secogramma/Delete/5

        public ActionResult Delete(int id)
        {
            var SecogrammaDelete = (from sc in db.Secogramma where sc.ID == id select sc).First();
            return View(SecogrammaDelete);
        }

        //
        // POST: /Secogramma/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var SecogrammaDelete = (from sc in db.Secogramma where sc.ID == id select sc).First();
            try
            {
                // TODO: Add delete logic here
                db.Secogramma.Remove(SecogrammaDelete);
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
