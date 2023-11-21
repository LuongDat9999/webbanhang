using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demoapp.Model;

namespace Demoapp.Controllers
{
    public class BoSuuTapController : Controller
    {
        WebBanQuanAoEntities2 database = new WebBanQuanAoEntities2();
        // GET: BoSuuTap
        public ActionResult Index()
        {
            return View(database.Collections.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Collection user)
        {
            database.Collections.Add(user);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(database.Collections.Where(s => s.Id == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.Collections.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Collection user)
        {
            database.Entry(user).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.Collections.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Collection user)
        {
            user = database.Collections.Where(s => s.Id == id).FirstOrDefault();
            database.Collections.Remove(user);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}