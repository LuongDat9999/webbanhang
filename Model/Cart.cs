using Demoapp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demoapp.Model
{
    public class CartItem
    {
        public Product product { get; set; }
        public int quantity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items { get { return items; } }
        public void AddProduct(Product pro, int quan=1)
        {
            var item = Items.FirstOrDefault(s => s.product.ProductID == pro.ProductID);
            //SanPhamController p = new SanPhamController();
            //quan = p.getNewQuan();
            if (item == null)
            {
                items.Add(new CartItem() { product = pro, quantity = quan });
            }
            else
            {
                item.quantity += quan;
            }
        }
        public int TotalQuantity()
        {
            return items.Sum(s => s.quantity);
        }
        public decimal TotalMoney()
        {
            var total = items.Sum(s => s.quantity * (s.product.Price-(s.product.Price*s.product.Discount)/100));
            return (decimal)total;
        }
        public void UpdateQuantity(int id, int newQuan)
        {
            var item = items.Find(s => s.product.ProductID == id);
            //SanPhamController p = new SanPhamController();
            //newQuan = p.getNewQuan();
            if (item != null)
            {
                item.quantity = newQuan;
            }
        }
        public void RemoveCart(int id)
        {
            items.RemoveAll(s => s.product.ProductID == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }

    }
}