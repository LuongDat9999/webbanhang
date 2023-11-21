using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using Demoapp.Model;
using System.Data.Entity;

namespace Demoapp.Controllers
{
    public class ProductController : Controller
    {
        WebBanQuanAoEntities2 database = new WebBanQuanAoEntities2();
        // GET: Product
        public ActionResult Index()
        {
            return View(database.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            Product pro = new Product();
            return View(pro);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {            
                // TODO: Add insert logic here
                if (pro.ImageUpload1 != null)
                {
                    string fileName1 = Path.GetFileNameWithoutExtension(pro.ImageUpload1.FileName);
                    string extension1 = Path.GetExtension(pro.ImageUpload1.FileName);

                    fileName1 = fileName1 + extension1;
                    pro.ImagePro1 = "~/Content/Images/" + fileName1;
                    pro.ImageUpload1.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName1));

                }
                if (pro.ImageUpload2 != null)
                {
                    string fileName2 = Path.GetFileNameWithoutExtension(pro.ImageUpload2.FileName);
                    string extension2 = Path.GetExtension(pro.ImageUpload2.FileName);

                    fileName2 = fileName2 + extension2;
                    pro.ImagePro2 = "~/Content/Images/" + fileName2;
                    pro.ImageUpload2.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName2));

                }
                if (pro.ImageUpload3 != null)
                {
                    string fileName3 = Path.GetFileNameWithoutExtension(pro.ImageUpload3.FileName);
                    string extension3 = Path.GetExtension(pro.ImageUpload3.FileName);

                    fileName3 = fileName3 + extension3;
                    pro.ImagePro3 = "~/Content/Images/" + fileName3;
                    pro.ImageUpload3.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName3));

                }
                if (pro.ImageUpload4 != null)
                {
                    string fileName4 = Path.GetFileNameWithoutExtension(pro.ImageUpload4.FileName);
                    string extension4 = Path.GetExtension(pro.ImageUpload4.FileName);

                    fileName4 = fileName4 + extension4;
                    pro.ImagePro4 = "~/Content/Images/" + fileName4;
                    pro.ImageUpload4.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName4));

                }
                database.Products.Add(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pro)
        {
            try
            {
                // TODO: Add update logic here
                if (pro.ImageUpload1 != null)
                {
                    string fileName1 = Path.GetFileNameWithoutExtension(pro.ImageUpload1.FileName);
                    string extension1 = Path.GetExtension(pro.ImageUpload1.FileName);

                    fileName1 = fileName1 + extension1;
                    pro.ImagePro1 = "~/Content/Images/" + fileName1;
                    pro.ImageUpload1.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName1));

                }
                if (pro.ImageUpload2 != null)
                {
                    string fileName2 = Path.GetFileNameWithoutExtension(pro.ImageUpload2.FileName);
                    string extension2 = Path.GetExtension(pro.ImageUpload2.FileName);

                    fileName2 = fileName2 + extension2;
                    pro.ImagePro2 = "~/Content/Images/" + fileName2;
                    pro.ImageUpload2.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName2));

                }
                if (pro.ImageUpload3 != null)
                {
                    string fileName3 = Path.GetFileNameWithoutExtension(pro.ImageUpload3.FileName);
                    string extension3 = Path.GetExtension(pro.ImageUpload3.FileName);

                    fileName3 = fileName3 + extension3;
                    pro.ImagePro3 = "~/Content/Images/" + fileName3;
                    pro.ImageUpload3.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName3));

                }
                if (pro.ImageUpload4 != null)
                {
                    string fileName4 = Path.GetFileNameWithoutExtension(pro.ImageUpload4.FileName);
                    string extension4 = Path.GetExtension(pro.ImageUpload4.FileName);

                    fileName4 = fileName4 + extension4;
                    pro.ImagePro4 = "~/Content/Images/" + fileName4;
                    pro.ImageUpload4.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName4));

                }
                database.Entry(pro).State = EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {
            try
            {

                // TODO: Add delete logic here
                pro = database.Products.Where(s => s.ProductID == id).FirstOrDefault();
                database.Products.Remove(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
