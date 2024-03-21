using BillionaireBooks.Models;
using BillionaireBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BillionaireBooks.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _repo;

        public HomeController(IBookstoreRepository context)
        {
            _repo = context;
        }


        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var Blah = new BookListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.BookId)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }

            };
            return View(Blah);
        }
    }
}
