using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> otp): base (otp)
        {
            
        }
        public DbSet<Book>? Books { get; set;}
    }
}
