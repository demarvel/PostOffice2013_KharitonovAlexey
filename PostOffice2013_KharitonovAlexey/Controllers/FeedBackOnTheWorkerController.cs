using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class FeedBackOnTheWorkerController : Controller
    {
        //
        // GET: /FeedBackOnTheWorker/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var FBOTWorker = (from fb in db.FeedbackOnTheWorker select fb).ToList();
            return View(FBOTWorker);
        }

        //
        // GET: /FeedBackOnTheWorker/Details/5

        public ActionResult Details(int id)
        {
            var FBOTWorkerDetails = (from fb in db.FeedbackOnTheWorker where fb.ID == id select fb).First();
            return View(FBOTWorkerDetails);
        }

        //
        // GET: /FeedBackOnTheWorker/Create

        public ActionResult Create()
        {
            FeedbackOnTheWorker fb = new FeedbackOnTheWorker();
            return View(fb);
        }

        //
        // POST: /FeedBackOnTheWorker/Create

        [HttpPost]
        public ActionResult Create(FeedbackOnTheWorker fb)
        {

            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.FeedbackOnTheWorker.Add(fb);
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
        // GET: /FeedBackOnTheWorker/Edit/5

        public ActionResult Edit(int id)
        {
            var FBOTWorkerEdit = (from fb in db.FeedbackOnTheWorker where fb.ID == id select fb).First();
            return View(FBOTWorkerEdit);
        }

        //
        // POST: /FeedBackOnTheWorker/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var FBOTWorkerEdit = (from fb in db.FeedbackOnTheWorker where fb.ID == id select fb).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(FBOTWorkerEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FeedBackOnTheWorker/Delete/5

        public ActionResult Delete(int id)
        {
            var FBOTWorkerDelete = (from fb in db.FeedbackOnTheWorker where fb.ID == id select fb).First();
            return View(FBOTWorkerDelete);
        }

        //
        // POST: /FeedBackOnTheWorker/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var FBOTWorkerDelete = (from fb in db.FeedbackOnTheWorker where fb.ID == id select fb).First();
            try
            {
                // TODO: Add delete logic here
                db.FeedbackOnTheWorker.Remove(FBOTWorkerDelete);
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
