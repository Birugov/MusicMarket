using BozheHvatitDushit_Sharp.Repository;
using BozheHvatitDushitSharp.Models;
using BozheHvatitDushitSharp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushitSharp.Controllers
{
    public class CartController:Controller
    {
        private readonly DBObjects _dbObj;
        private readonly Cart _Cart;
        public CartController(DBObjects dbObj, Cart cart)
        {
            _dbObj = dbObj;
            _Cart = cart;
        }

        public ViewResult Index()
        {
            var items = _Cart.GetItems();
            _Cart.cartItems = items;
            var obj = new CartViewModel
            {
                shopCart = _Cart
            };
            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _dbObj.Items.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _Cart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

    }
}
