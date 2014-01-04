using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class PostCardController : Controller
    {
        //
        // GET: /PostCard/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var PostCard = (from pc in db.PostCard select pc).ToList();
            return View(PostCard);
        }

        //
        // GET: /PostCard/Details/5

        public ActionResult Details(int id)
        {
            var PostCardDetails = (from pc in db.PostCard where pc.ID == id select pc).First();
            return View(PostCardDetails);
        }

        //
        // GET: /PostCard/Create

        public ActionResult Create()
        {
            PostCard pc = new PostCard();
            return View(pc);
        }

        //
        // POST: /PostCard/Create

        [HttpPost]
        public ActionResult Create(PostCard pc)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.PostCard.Add(pc);
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
        // GET: /PostCard/Edit/5

        public ActionResult Edit(int id)
        {
            var PostCardEdit = (from pc in db.PostCard where pc.ID == id select pc).First();
            return View(PostCardEdit);
        }

        //
        // POST: /PostCard/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var PostCardEdit = (from pc in db.PostCard where pc.ID == id select pc).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(PostCardEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PostCard/Delete/5

        public ActionResult Delete(int id)
        {
            var PostCardDelete = (from pc in db.PostCard where pc.ID == id select pc).First();
            return View(PostCardDelete);
        }

        //
        // POST: /PostCard/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var PostCardDelete = (from pc in db.PostCard where pc.ID == id select pc).First();
            
            try
            {
                // TODO: Add delete logic here
                
                db.PostCard.Remove(PostCardDelete);
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
