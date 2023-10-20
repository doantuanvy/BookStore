using BookStore.Data;
using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBookAsync();
        public Task<BookModel> GetBookAsync(int id);
        public Task<int> AddBookAsync (BookModel book);
        public Task DeleteBookAsync (int id);
        public Task UpdateBookAsync (int id, BookModel book);
    }
}
