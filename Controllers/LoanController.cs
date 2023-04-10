using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMALS.Data;
using SMALS.Models;

namespace SMALS.Controllers
{
    public class LoanController : Controller
    {
        private readonly ApplicationDbContext _context;
		public LoanController(ApplicationDbContext context)
		{
            _context = context;
		}
        public IActionResult Index()
        {
            var loans = _context.Loans.Include(l => l.Book).ToList();
            return View(loans);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string isbn)
		{
            var book = await GetBookByISBN(isbn);

            if (!book.Status)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _context.Users.FirstOrDefaultAsync();

            if (book == null || user == null)
            {
                return NotFound();
            }

            var loan = new Loan
            {
                Book = book,
                BookId = book.Id,
                User = user,
                UserId = user.Id,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14)
            };

            book.Status = false;
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string isbn)
		{
            var loan = await _context.Loans.FirstOrDefaultAsync(m => m.Book.ISBN == isbn);
            var book = await GetBookByISBN(isbn);

            if (loan == null)
            {
                return NotFound();
            }

            if(!book.Status)
            {
                book.Status = true;
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<Book> GetBookByISBN(string isbn)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
        }
    }
}
