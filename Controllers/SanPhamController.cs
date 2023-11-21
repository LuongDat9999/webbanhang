using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demoapp.Model;
using Microsoft.Win32;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Data;

namespace Demoapp.Controllers
{
    public class SanPhamController : Controller
    {
        WebBanQuanAoEntities2 database = new WebBanQuanAoEntities2();
        // GET: SanPham
        
        
        public ActionResult Show(string style, string category, int? page, string search)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            var productList = database.Products.OrderByDescending(s => s.NamePro);

            if (search != null)
            {
                return View(database.Products.Where(s => s.NamePro.Contains(search)));
            }
            if (category != null)
            {
                productList = (IOrderedQueryable<Product>)productList.Where(m => m.Category == category);       
            }
            
            if (style != null)
            {
                productList = (IOrderedQueryable<Product>)productList.Where(m => m.Category == style);    
            }
            return View(productList.ToPagedList(pageNum, pageSize));

        }
        //Search
        public ActionResult Search(string search)
        {
            if (search != null)
            {
                return View(database.Products.Where(s => s.NamePro.Contains(search)));
            }
            else
            {
                return View(database.Products.ToList());
            }
        }
        //public int q=1;
    
        public ActionResult DetailPro(int id,FormCollection frm)
        {
           
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault()) ;
        }
        public ActionResult Sale(string category , int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            if (category == null)
            {
                var productList = database.Products.OrderByDescending(x => x.NamePro);
                return View(productList.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var productList = database.Products.OrderByDescending(x => x.NamePro)
                    .Where(p => p.Category == category);
                return View(productList);
            }
        }
        public ActionResult BoSuuTam(string style,string colection,int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            var productList = database.Products.OrderByDescending(s => s.NamePro);

            if (colection != null)
            {
                productList = (IOrderedQueryable<Product>)productList.Where(m => m.Collection == colection);
            }

            if (style != null)
            {
                productList = (IOrderedQueryable<Product>)productList.Where(m => m.Collection == style);

            }
            return View(productList.ToPagedList(pageNum, pageSize));
        }
        public ActionResult ShowAo()
        {
         
            return View(database.Products.Where(s => s.Category == "1").ToList());
        }
        public ActionResult ShowQuan()
        {

            return View(database.Products.Where(s => s.Category == "2").ToList());
        }
        public ActionResult ShowSetBo()
        {

            return View(database.Products.Where(s => s.Category == "3").ToList());
        }
        public ActionResult ShowDam()
        {

            return View(database.Products.Where(s => s.Category == "4").ToList());
        }
    }
}
