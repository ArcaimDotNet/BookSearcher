using System.Threading.Tasks;
using BookSearcher.Models;
using BookSearcher.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookSearcher.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchBook([FromForm] Book book)
        {
            return View(await _bookService.Search(book));
        }
    }
}