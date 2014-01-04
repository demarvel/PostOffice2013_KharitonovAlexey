using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class WorkerController : Controller
    {
        //
        // GET: /Worker/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var Worker = (from wr in db.Worker select wr).ToList();
            return View(Worker);
        }

        //
        // GET: /Worker/Details/5

        public ActionResult Details(int id)
        {
            var WorkerDetails = (from wr in db.Worker where wr.ID == id select wr).First();
            return View(WorkerDetails);
        }

        //
        // GET: /Worker/Create

        public ActionResult Create()
        {
            Worker wr = new Worker();
            return View(wr);
        }

        //
        // POST: /Worker/Create

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
                ModelState.AddModelError(String.Empty,ex);
            }
            return View();
        }

        //
        // GET: /Worker/Edit/5

        public ActionResult Edit(int id)
        {
            var WorkerEdit = (from wr in db.Worker where wr.ID == id select wr).First();
            return View(WorkerEdit);
        }

        //
        // POST: /Worker/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var WorkerEdit = (from wr in db.Worker where wr.ID == id select wr).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(WorkerEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Worker/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Worker wr1 = db.Worker.Find(id);
            //var WorkerDelete = (from wr in db.Worker where wr.ID == id select wr).First();
            return View(wr1);
        }

        //
        // POST: /Worker/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //var WorkerDelete = (from wr in db.Worker where wr.ID == id select wr).First();
            //try
            //{
                // TODO: Add delete logic here
                Worker wr1 = db.Worker.Find(id);
                var Workers = db.Worker.Where(m => m.PostIndex == id);
                var PostOf = db.PostItem.Where(m => m.IDWorker == wr1.ID);
                foreach (var item2 in PostOf)
                {
                    item2.IDWorker = 0;
                }
                var SaleOfGoods = db.SaleOfGoods.Where(m => m.IDWorker == wr1.ID);
                foreach (var item3 in SaleOfGoods)
                {
                    item3.IDWorker = 0;
                }
                var Pension = db.PensionPayment.Where(m => m.IDWorker == wr1.ID);
                foreach (var item4 in Pension)
                {
                    item4.IDWorker = 0;
                }
                db.SaveChanges();
                db.Worker.Remove(wr1);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
