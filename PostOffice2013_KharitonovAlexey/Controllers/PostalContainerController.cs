using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class PostalContainerController : Controller
    {
        //
        // GET: /PostalContainer/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var PostalContainer = (from pc in db.PostalContainer select pc).ToList();
            return View(PostalContainer);
        }

        //
        // GET: /PostalContainer/Details/5

        public ActionResult Details(int id)
        {
            var PostalDetails = (from pc in db.PostalContainer where pc.ID == id select pc).First();
            return View(PostalDetails);
        }

        //
        // GET: /PostalContainer/Create

        public ActionResult Create()
        {
            PostalContainer pc = new PostalContainer();
            return View(pc);
        }

        //
        // POST: /PostalContainer/Create

        [HttpPost]
        public ActionResult Create(PostalContainer pc)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.PostalContainer.Add(pc);
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
        // GET: /PostalContainer/Edit/5

        public ActionResult Edit(int id)
        {
            var PostalEdit = (from pc in db.PostalContainer where pc.ID == id select pc).First();
            return View(PostalEdit);
        }

        //
        // POST: /PostalContainer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var PostalEdit = (from pc in db.PostalContainer where pc.ID == id select pc).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(PostalEdit); db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PostalContainer/Delete/5

        public ActionResult Delete(int id)
        {
            var PostalDelete = (from pc in db.PostalContainer where pc.ID == id select pc).First();
            return View(PostalDelete);
        }

        //
        // POST: /PostalContainer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var PostalDelete = (from pc in db.PostalContainer where pc.ID == id select pc).First();
            try
            {
                // TODO: Add delete logic here
                db.PostalContainer.Remove(PostalDelete);
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
