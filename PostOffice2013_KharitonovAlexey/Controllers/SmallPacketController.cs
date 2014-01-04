using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class SmallPacketController : Controller
    {
        //
        // GET: /SmallPacket/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var SmallPacket = (from sp in db.SmallPacket select sp).ToList();
            return View(SmallPacket);
        }

        //
        // GET: /SmallPacket/Details/5

        public ActionResult Details(int id)
        {
            var SmallPacketDetails = (from sp in db.SmallPacket where sp.ID == id select sp).First();
            return View(SmallPacketDetails);
        }

        //
        // GET: /SmallPacket/Create

        public ActionResult Create()
        {
            SmallPacket sp = new SmallPacket();
            return View(sp);
        }

        //
        // POST: /SmallPacket/Create

        [HttpPost]
        public ActionResult Create(SmallPacket sp)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.SmallPacket.Add(sp);
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
        // GET: /SmallPacket/Edit/5

        public ActionResult Edit(int id)
        {
            var SmallPacketEdit = (from sp in db.SmallPacket where sp.ID == id select sp).First();
            return View(SmallPacketEdit);
        }

        //
        // POST: /SmallPacket/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var SmallPacketEdit = (from sp in db.SmallPacket where sp.ID == id select sp).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(SmallPacketEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SmallPacket/Delete/5

        public ActionResult Delete(int id)
        {
            var SmallPacketDelete = (from sp in db.SmallPacket where sp.ID == id select sp).First();
            return View(SmallPacketDelete);
        }

        //
        // POST: /SmallPacket/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var SmallPacketDelete = (from sp in db.SmallPacket where sp.ID == id select sp).First();
            try
            {
                // TODO: Add delete logic here
                db.SmallPacket.Remove(SmallPacketDelete);
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
