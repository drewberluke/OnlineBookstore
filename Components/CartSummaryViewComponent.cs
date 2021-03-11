using System;
using Microsoft.AspNetCore.Mvc;
using assignment5.Models;

namespace assignment5.Components
{
    public class CartSummaryViewComponent : ViewComponent 
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
