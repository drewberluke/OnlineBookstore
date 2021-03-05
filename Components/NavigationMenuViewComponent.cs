using System;
using System.Linq;
using assignment5.Models;
using Microsoft.AspNetCore.Mvc;

namespace assignment5.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRepository repository;
        
        public NavigationMenuViewComponent (IBookRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Selected = RouteData?.Values["category"];

            return View(repository.Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(b => b));
        }
    }
}
