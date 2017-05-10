using CarPartsShop.Data;
using CarPartsShop.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarPartsShop.WebApi.Controllers
{
    public class StoreFrontController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: StoreFront
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
    }
}