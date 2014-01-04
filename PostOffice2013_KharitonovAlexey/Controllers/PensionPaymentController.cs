using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class PensionPaymentController : Controller
    {
        //
        // GET: /PensionPayment/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var PensionPayment = (from pp in db.PensionPayment select pp).ToList();
            return View(PensionPayment);
        }

        //
        // GET: /PensionPayment/Details/5

        public ActionResult Details(int id)
        {
            var PensionPaymentDetails = (from pp in db.PensionPayment where pp.IDPayment == id select pp).First();
            return View(PensionPaymentDetails);
        }

        //
        // GET: /PensionPayment/Create

        public ActionResult Create()
        {
            PensionPayment pp = new PensionPayment();
            return View(pp);
        }

        //
        // POST: /PensionPayment/Create

        [HttpPost]
        public ActionResult Create(PensionPayment pp)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.PensionPayment.Add(pp);
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
        // GET: /PensionPayment/Edit/5

        public ActionResult Edit(int id)
        {
            var PensionPaymentEdit = (from pp in db.PensionPayment where pp.IDPayment == id select pp).First();
            return View(PensionPaymentEdit);
        }

        //
        // POST: /PensionPayment/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var PensionPaymentEdit = (from pp in db.PensionPayment where pp.IDPayment == id select pp).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(PensionPaymentEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PensionPayment/Delete/5

        public ActionResult Delete(int id)
        {
            var PensionPaymentDelete = (from pp in db.PensionPayment where pp.IDPayment == id select pp).First();
            return View(PensionPaymentDelete);
        }

        //
        // POST: /PensionPayment/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var PensionPaymentDelete = (from pp in db.PensionPayment where pp.IDPayment == id select pp).First();
            try
            {
                // TODO: Add delete logic here
                db.PensionPayment.Remove(PensionPaymentDelete);
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
