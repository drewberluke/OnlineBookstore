using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //private IBookRepository repository;

        public virtual void AddItem(BookModel book, int qty)
        {
            CartLine line = Lines.Where(b => b.Book.Id == book.Id).FirstOrDefault();

            if (line  == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //public IActionResult RemoveCartItem(int Id, string returnUrl)
        //{
        //    BookModel book = repository.Books.FirstOrDefault(b => b.Id == Id);

        //    Cart Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        //}

        //public virtual void RemoveCartItem(int Id, string returnUrl)
        //{
        //    BookModel book = (BookModel)Lines.Where(b => b.Book.Id == Id).FirstOrDefault();
        //}

        public virtual void RemoveLine(BookModel book) =>
            Lines.RemoveAll(l => l.Book.Id == book.Id);

        public virtual void Clear() => Lines.Clear();

        public double ComputeTotal()
        {
            return Lines.Sum(b => b.Book.Price * b.Quantity);
        }

        public class CartLine
        {
            public int CartLineId { get; set; }
            public BookModel Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
