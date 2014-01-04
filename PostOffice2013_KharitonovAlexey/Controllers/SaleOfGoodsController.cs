using PostOffice2013_KharitonovAlexey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey.Controllers
{
    public class SaleOfGoodsController : Controller
    {
        //
        // GET: /SaleOfGoods/
        private PostOffice2013DBEntities1 db = new PostOffice2013DBEntities1();
        public ActionResult Index()
        {
            var SOGoods = (from sg in db.SaleOfGoods select sg).ToList();
            return View(SOGoods);
        }

        //
        // GET: /SaleOfGoods/Details/5

        public ActionResult Details(int id)
        {
            var SOGoodsDetails = (from sg in db.SaleOfGoods where sg.ID == id select sg).First();
            return View(SOGoodsDetails);
        }

        //
        // GET: /SaleOfGoods/Create

        public ActionResult Create()
        {
            SaleOfGoods sg = new SaleOfGoods();
            return View(sg);
        }

        //
        // POST: /SaleOfGoods/Create

        [HttpPost]
        public ActionResult Create(SaleOfGoods sg)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.SaleOfGoods.Add(sg);
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
        // GET: /SaleOfGoods/Edit/5

        public ActionResult Edit(int id)
        {
            var SOGoodsEdit = (from sg in db.SaleOfGoods where sg.ID == id select sg).First();
            return View(SOGoodsEdit);
        }

        //
        // POST: /SaleOfGoods/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var SOGoodsEdit = (from sg in db.SaleOfGoods where sg.ID == id select sg).First();
            try
            {
                // TODO: Add update logic here
                UpdateModel(SOGoodsEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SaleOfGoods/Delete/5

        public ActionResult Delete(int id)
        {
            var SOGoodsDelete = (from sg in db.SaleOfGoods where sg.ID == id select sg).First();
            return View(SOGoodsDelete);
        }

        //
        // POST: /SaleOfGoods/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var SOGoodsDelete = (from sg in db.SaleOfGoods where sg.ID == id select sg).First();
            try
            {
                // TODO: Add delete logic here
                db.SaleOfGoods.Remove(SOGoodsDelete);
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
