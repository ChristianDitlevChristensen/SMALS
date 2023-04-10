using Microsoft.EntityFrameworkCore;
using SMALS.Models;

namespace SMALS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
