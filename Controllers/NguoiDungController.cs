using Demoapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Data.Entity;

namespace Demoapp.Controllers
{
    public class NguoiDungController : Controller
    {
        WebBanQuanAoEntities2 database = new WebBanQuanAoEntities2();
        // GET: NguoiDung
        public ActionResult Login()
        {
            Session["user"] = null;
            return View();
        }
        public ActionResult XTLogin(Customer user)
        {
            var checkemail = database.Customers.Where(s => s.EmailCus == user.EmailCus).FirstOrDefault();
            var checkpass = database.Customers.Where(s => s.Password == user.Password).FirstOrDefault();
            try
            {
                if (checkemail == null || checkpass == null)
                {
                    if (checkemail == null)
                        ViewBag.ErrorEmail = "Email không đúng";
                    if (checkpass == null)
                        ViewBag.ErrorPass = "Mật khẩu không đúng";
                    return View("Login");

                }
                else
                {
                    Session["user"] = user.EmailCus;
                    return RedirectToAction("TrangChu", "Home");
                }
            }
            catch
            {
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult XTLogout(Customer user)
        {
            if (ModelState.IsValid)
            {
                var checkema = database.Customers.Where(m => m.EmailCus == user.EmailCus).FirstOrDefault();
                if (checkema == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.Customers.Add(user);
                    database.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.ErrorDK = "Email đã tồn tại";
                    return View("Logout");
                }
            }
            return View("logout");

        }
 
        public ActionResult Profile()
        {
            return View(database.Customers.ToList());
        }
        public ActionResult Edit(int id)
        {
            return View(database.Customers.Where(m => m.IDCus == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Customer user)
        {
            database.Entry(user).State = System.Data.Entity.EntityState.Modified;     
            database.SaveChanges();
            return RedirectToAction("Profile");
        }
    }
}