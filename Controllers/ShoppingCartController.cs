using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demoapp.Model;

namespace Demoapp.Controllers
{
    public class ShoppingCartController : Controller
    {
        WebBanQuanAoEntities2 database = new WebBanQuanAoEntities2();
        // GET: ShoppingCart
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("ShowCart", "ShoppingCart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            
            var pro = database.Products.SingleOrDefault(s => s.ProductID == id);
            if (pro != null)
            {
                GetCart().AddProduct(pro);
                

            }
            return RedirectToAction("ShowCart", "ShoppingCart");

        }
        public ActionResult UpdateCartQuantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int idpro = int.Parse(form["idPro"]);
          
            int quantity = int.Parse(form["cartQuan"]);
            cart.UpdateQuantity(idpro,quantity);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.RemoveCart(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int totalquantityitem = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                totalquantityitem = cart.TotalQuantity();
            ViewBag.QuantityCart = totalquantityitem;
            return PartialView("BagCart");
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                OrderPro order = new OrderPro();//Bảng hoá đơn sản phẩm
                order.DateOrder = DateTime.Now;
                order.AddressDeliverry = form["AddressDeliverry"];
                order.IDCus = int.Parse(form["CodeCustomer"]);
                database.OrderProes.Add(order);
                foreach (var item in cart.Items)
                {
                    OrderDetail detail = new OrderDetail();//Lưu dòng sản phẩm vào bảng chi tết hoá đơn
                    detail.IDOrder = order.ID;
                    detail.IDProduct = item.product.ProductID;
                    detail.UnitPrice = (double)item.product.Price;
                    detail.Quantity = item.quantity;
                    database.OrderDetails.Add(detail);
                }
                database.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckOutSuccess", "ShoppingCart");
            }
            catch
            {
                return Content("Lỗi!!! Vui lòng kiểm tra thông tin khác hàng");
            }


        }
        public ActionResult CheckOutSuccess()
        {
            return View();
        }
        public ActionResult ReCheckOut()
        {
            return View();
        }
        public ActionResult EmptyCart()
        {
            return View();
        }
    }
}