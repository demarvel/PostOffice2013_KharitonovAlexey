using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class PostOfficeController : Controller
    {
        //
        // GET: /PostOffice/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var PostOffice = (from po in db.PostOffice select po).ToList();
            return View(PostOffice);
        }

        //
        // GET: /PostOffice/Details/5

        public ActionResult Details(int id)
        {
            var PostOfficeDetails = (from po in db.PostOffice where po.PostIndex == id select po).First();
            return View(PostOfficeDetails);
        }

        //
        // GET: /PostOffice/Create

        public ActionResult Create()
        {
            PostOffice po = new PostOffice();
            return View(po);
        }

        //
        // POST: /PostOffice/Create

        [HttpPost]
        public ActionResult Create(PostOffice po)
        {
            try
            {

                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.PostOffice.Add(po);
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
        // GET: /PostOffice/Edit/5

        public ActionResult Edit(int id)
        {
            var PostOfficeEdit = (from po in db.PostOffice where po.PostIndex == id select po).First();
            return View(PostOfficeEdit);
        }

        //
        // POST: /PostOffice/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var PostOfficeEdit = (from po in db.PostOffice where po.PostIndex == id select po).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(PostOfficeEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PostOffice/Delete/5

        public ActionResult Delete(int id)
        {
            var PostOfficeDelete = (from po in db.PostOffice where po.PostIndex == id select po).First();
            return View(PostOfficeDelete);
        }

        //
        // POST: /PostOffice/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var PostOfficeDelete = (from po in db.PostOffice where po.PostIndex == id select po).First();
            /*var WorckerDelete = (from wr in db.Worker where wr.PostIndex == id select wr).ToList();
            //var PensionerDelete = from pd in db*/
            
            try
            {
                // TODO: Add delete logic here
                /*for(int i =0; i<= WorckerDelete.Count;i++)
                {
                    db.Worker.Remove(WorckerDelete[i]);
                }
                db.SaveChanges();*/
                db.PostOffice.Remove(PostOfficeDelete);
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
