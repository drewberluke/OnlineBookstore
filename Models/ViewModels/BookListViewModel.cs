using System;
using System.Collections.Generic;

namespace assignment5.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<BookModel> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }   
}
