using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class LetterController : Controller
    {
        //
        // GET: /Letter/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var Letter = (from lt in db.Letter select lt).ToList();
            return View(Letter);
        }

        //
        // GET: /Letter/Details/5

        public ActionResult Details(int id)
        {
            var LetterDeltails = (from lt in db.Letter where lt.ID == id select lt).First();
            return View(LetterDeltails);
        }

        //
        // GET: /Letter/Create

        public ActionResult Create()
        {
            Letter lt = new Letter();
            return View(lt);
        }

        //
        // POST: /Letter/Create

        [HttpPost]
        public ActionResult Create(Letter lt)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Letter.Add(lt);
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
        // GET: /Letter/Edit/5

        public ActionResult Edit(int id)
        {
            var LetterEdit = (from lt in db.Letter where lt.ID == id select lt).First();
            return View(LetterEdit);
        }

        //
        // POST: /Letter/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var LetterEdit = (from lt in db.Letter where lt.ID == id select lt).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(LetterEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Letter/Delete/5

        public ActionResult Delete(int id)
        {
            var LetterDelete = (from lt in db.Letter where lt.ID == id select lt).First();
            return View(LetterDelete);
        }

        //
        // POST: /Letter/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var LetterDelete = (from lt in db.Letter where lt.ID == id select lt).First();
            try
            {
                // TODO: Add delete logic here
                db.Letter.Remove(LetterDelete);
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
