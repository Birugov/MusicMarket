using BozheHvatitDushit_Sharp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushitSharp.Models
{
    public class Cart
    {
        public readonly PurchaseContext itemContext;
        public Cart(PurchaseContext itemContext)
        {
            this.itemContext = itemContext;
        }
        public string CartId { get; set; }
        public List<CartItem> cartItems { get; set; }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<PurchaseContext>();
            string CartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", CartId);
            return new Cart(context) { CartId = CartId };
        }
        [HttpPost]
        public void AddToCart(Item item)
        {
            this.itemContext.CartItems.Add(new CartItem
            {
                CartId = CartId,
                item = item,
                price = item.price
            });
            itemContext.SaveChanges();
        }
        public List<CartItem> GetItems()
        {
            return itemContext.CartItems.Where(x => x.CartId == CartId).Include(c => c.item).ToList();
        }
    } 
}
