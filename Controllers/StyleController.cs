using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demoapp.Model;

namespace Demoapp.Controllers
{
    public class StyleController : Controller
    {
        WebBanQuanAoEntities2 database = new WebBanQuanAoEntities2();
        // GET: Style
        public ActionResult Index()
        {
            var list = database.Categories.ToList();
            ViewBag.listStyle = list;
            return PartialView(list);
        }
       
            
        public ActionResult Stylebst()
        {
            var list = database.Collections.ToList();
            ViewBag.listStyle = list;
            return PartialView(list);
        }
        public ActionResult DetailCate(int? id)
        {
            var list = database.Collections.ToList();
            ViewBag.listStyle = list;
            return PartialView(list);
        }
        [HttpPost]
        public ActionResult SuaThongTin(int? id, Customer User)
        {
            database.Entry(User).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("DanhSachUser");
        }
        //DetailUser
        public ActionResult ChiTietUser(int? id)
        {
            return View(database.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }

        //DeleteUser
        public ActionResult XoaUser(int? id)
        {
            return View(database.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult XoaUser(int? id, Customer User)
        {
            User = database.Customers.Where(s => s.IDCus == id).FirstOrDefault();
            database.Customers.Remove(User);
            database.SaveChanges();
            return RedirectToAction("DanhSachUser");
        }

    }
}