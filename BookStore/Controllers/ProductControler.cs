using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public ProductControler(IBookRepository repo )
        {
            _bookRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks() {
            try
            {
                return Ok(await _bookRepo.GetAllBookAsync());
            }       
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookRepo.GetBookAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                else return Ok(book);
                
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            try
            {
                var bookId = await _bookRepo.AddBookAsync(bookModel);
               
                    return Ok(bookId);
                

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateBook(int id, BookModel bookModel)
        {
            try
            {
                await _bookRepo.UpdateBookAsync(id, bookModel);


                return Ok();


            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteBook(int id)
        {
            try
            {
                await _bookRepo.DeleteBookAsync(id);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
