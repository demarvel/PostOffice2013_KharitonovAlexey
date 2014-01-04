using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class PostItemController : Controller
    {
        //
        // GET: /PostItem/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var PostItem = (from pi in db.PostItem select pi).ToList();
            return View(PostItem);
        }

        //
        // GET: /PostItem/Details/5

        public ActionResult Details(int id)
        {
            var PostItemDetails = (from pi in db.PostItem where pi.ID == id select pi).First();
            return View(PostItemDetails);
        }

        //
        // GET: /PostItem/Create

        public ActionResult Create()
        {
            PostItem pi = new PostItem();
            return View(pi);
        }

        //
        // POST: /PostItem/Create

        [HttpPost]
        public ActionResult Create(PostItem pi)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.PostItem.Add(pi);
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
        // GET: /PostItem/Edit/5
        public ActionResult Edit(int id)
        {
            var PostItemEdit = (from pi in db.PostItem where pi.ID == id select pi).First();
            return View(PostItemEdit);
        }

        //
        // POST: /PostItem/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var PostItemEdit = (from pi in db.PostItem where pi.ID == id select pi).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(PostItemEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PostItem/Delete/5

        public ActionResult Delete(int id)
        {
            var PostItemDelete = (from pi in db.PostItem where pi.ID == id select pi).First();
            return View(PostItemDelete);
        }

        //
        // POST: /PostItem/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var PostItemDelete = (from pi in db.PostItem where pi.ID == id select pi).First();
            try
            {
                // TODO: Add delete logic here
                db.PostItem.Remove(PostItemDelete);
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
