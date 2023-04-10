using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMALS.Data;
using SMALS.Models;

namespace SMALS.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public async Task<IActionResult> Search(string isbn, string author, string title)
        {
            if (string.IsNullOrEmpty(isbn) && string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
            {
                return View(nameof(Index), new List<Book>());
            }

            var booksQuery = _context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(isbn))
            {
                booksQuery = booksQuery.Where(b => b.ISBN == isbn);
            }

            if (!string.IsNullOrEmpty(author))
            {
                booksQuery = booksQuery.Where(b => b.Author.ToLower().Contains(author.ToLower()));
            }

            if (!string.IsNullOrEmpty(title))
            {
                booksQuery = booksQuery.Where(b => b.Title.ToLower().Contains(title.ToLower()));
            }

            var books = booksQuery.ToList();

            return View(nameof(Index), books);
        }
    }
}
