//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using assignment5.Models;
//using assignment5.Infrastructure;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace assignment5.Controllers
//{
//    public class CartController : Controller
//    {
//        private IBookRepository repository;

//        private Cart cart;

//        public CartController(IBookRepository repo, Cart cartService)
//        {
//            repository = repo;
//            cart = cartService;
//        }

//        public RedirectToActionResult RemoveCartItem(int Id, string returnUrl)
//        {
//            BookModel book = repository.Books.FirstOrDefault(b => b.Id == Id);

//            if (book != null)
//            {
//                Cart cart = GetCart();
//                cart.RemoveLine(book);
//                SaveCart(cart);
//            }
//            return RedirectToAction("Index", new { returnUrl });
//        }

//        private Cart GetCart()
//        {
//            Cart cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
//            return cart;
//        }

//        private void SaveCart(Cart cart)
//        {
//            HttpContext.Session.SetJson("cart", cart);
//        }
//    }
//}
