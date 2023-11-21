using Demoapp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demoapp.Controllers
{
    public class QuanlyController : Controller
    {
        WebBanQuanAoEntities2 database = new WebBanQuanAoEntities2();
        // GET: Quanly
        //ListUser
        public ActionResult DanhSachUser()
        {
            return View(database.Customers.ToList());
        }

        //EditUser
        public ActionResult SuaThongTin(int id)
        {
            return View(database.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaThongTin(int id, Customer user)
        {
            database.Entry(user).State = System.Data.Entity.EntityState.Modified;
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
        public ActionResult DNAdmin()
        {
            return View();
        }
        public ActionResult XTLogin(AdminUser user)
        {
            try
            {
                var checkid = database.AdminUsers.Where(m => m.RoleUser == user.RoleUser).FirstOrDefault();
                var checkpass = database.AdminUsers.Where(m => m.PasswordUser == user.PasswordUser).FirstOrDefault();
                if (checkid == null || checkpass == null)
                {
                    if (checkid == null)
                        ViewBag.ErrorID = "Role không tồn tại";
                    if (checkpass == null)
                        ViewBag.ErrorPass = "Password không tồn tại";
                    return View("DNAdmin");
                }
                else
                {
                    return RedirectToAction("TrangQuanli","Quanly");
                }

            }
            catch
            {
                return View("DNAdmin");
            }
        }
        public ActionResult TrangQuanli()
        {
            return View();
        }
        public ActionResult DonDatHang()
        {
            return View(database.OrderProes.ToList());
        }
        public ActionResult ChiTietDonHang(int id)
        {
            return View(database.OrderDetails.Where(s=>s.IDOrder==id).FirstOrDefault());
        }

    }
}