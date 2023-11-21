using Demoapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demoapp.Controllers
{
    public class ProductClientController : Controller
    {
        WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
        // GET: ProductClient
        public ActionResult Index(string collect)
        {
            if (collect != null)
            {
                return View(db.Products.Where(s => s.Collection == collect).ToList());
            }
            return View(db.Products.ToList());
        }
    }
}