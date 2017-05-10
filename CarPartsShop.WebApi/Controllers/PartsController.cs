using CarPartsShop.Data;
using CarPartsShop.Models.EntityModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarPartsShop.WebApi.Controllers
{
    public class PartsController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Parts
        [HttpGet]
        public ActionResult Index()
        {
            var parts = db.Parts.Include(p => p.Category);
            return View(parts.ToList());
        }

        //GET: Parts/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }

            return View(part);
        }

        // GET: Parts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Parts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,InStock,DateAdded,Condition,CategoryId")] Part part)
        {
            if (ModelState.IsValid)
            {
                Part newPart = new Part()
                {
                    Name = part.Name,
                    Price = part.Price,
                    InStock = part.InStock,
                    DateAdded = part.DateAdded,
                    CategoryId = part.CategoryId
                };

                var userId = this.User.Identity.GetUserId();
                ApplicationUser user = db.Users.Find(userId);
                user.Parts.Add(newPart);

                db.Parts.Add(newPart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", part.CategoryId);
            return View(part);
        }


        // GET: Parts/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part product = db.Parts.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Parts/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,InStock,DateAdded,Condition,CategoryId")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Entry(part).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", part.CategoryId);
            return View(part);
        }

        // GET: Parts/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part product = db.Parts.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Parts/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Part product = db.Parts.Find(id);
            db.Parts.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}