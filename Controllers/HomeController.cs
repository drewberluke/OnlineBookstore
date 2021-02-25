using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using assignment5.Models;
using assignment5.Models.ViewModels;

namespace assignment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //create repo variable based on the book repo 
        private IBookRepository _repository;

        //set the number of books per page to 5
        public int ItemsPerPage = 5;

        //set repo equal to the book repo 
        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //send the results of the database query to the view
        public IActionResult Index(int page = 1)
        {
            return View(new BookListViewModel
            {
                Books = _repository.Books
                    .OrderBy(b => b.Id)
                    .Skip((page -1) * ItemsPerPage)
                    .Take(ItemsPerPage),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = ItemsPerPage,
                    TotalNumItems = _repository.Books.Count()
                }
            });
        }

        //send the results of the database query to the view
        public IActionResult assignment5()
        {
            return View(_repository.Books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
