using Demoapp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demoapp.Model;

namespace Demoapp.Controllers
{
    public class CategoryController : Controller
    {
        WebBanQuanAoEntities2 database = new WebBanQuanAoEntities2();
        // GET: Category
        public ActionResult Index()
        {
            return View(database.Categories.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category user)
        {
            database.Categories.Add(user);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(database.Categories.Where(s => s.Id == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.Categories.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Category user)
        {
            database.Entry(user).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.Categories.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Category user)
        {
           user = database.Categories.Where(s => s.Id == id).FirstOrDefault();
            database.Categories.Remove(user);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}