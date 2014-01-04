using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class PosilkaController : Controller
    {
        //
        // GET: /Posilka/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var Posilka = (from po in db.Posilka select po).ToList();
            return View(Posilka);
        }

        //
        // GET: /Posilka/Details/5

        public ActionResult Details(int id)
        {
            var PosilkaDetails = (from po in db.Posilka where po.ID == id select po).First();
            return View(PosilkaDetails);
        }

        //
        // GET: /Posilka/Create

        public ActionResult Create()
        {
            Posilka po = new Posilka();
            return View(po);
        }

        //
        // POST: /Posilka/Create

        [HttpPost]
        public ActionResult Create(Posilka po)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Posilka.Add(po);
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
        // GET: /Posilka/Edit/5

        public ActionResult Edit(int id)
        {
            var PosilkaEdit = (from po in db.Posilka where po.ID == id select po).First();
            return View(PosilkaEdit);
        }

        //
        // POST: /Posilka/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var PosilkaEdit = (from po in db.Posilka where po.ID == id select po).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(PosilkaEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Posilka/Delete/5

        public ActionResult Delete(int id)
        {
            var PosilkaDelete = (from po in db.Posilka where po.ID == id select po).First();
            return View(PosilkaDelete);
        }

        //
        // POST: /Posilka/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var PosilkaDelete = (from po in db.Posilka where po.ID == id select po).First();
            try
            {
                // TODO: Add delete logic here
                db.Posilka.Remove(PosilkaDelete);
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
