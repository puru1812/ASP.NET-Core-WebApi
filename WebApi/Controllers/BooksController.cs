using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        public BooksController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Book>> GetAll() =>
        BookService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = BookService.Get(id);

            if (book == null)
                return NotFound();

            return book;
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            // This code will save the book and return a result
            BookService.Add(book);

           
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,Book book)
        {
            // This code will update the book and return a result
            if (id != book.Id)
                return BadRequest();

            var existingBook = BookService.Get(id);
            if (existingBook is null)
                return NotFound();

            BookService.Update(book);

            return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = BookService.Get(id);

            if (book is null)
                return NotFound();

            BookService.Delete(id);

            return NoContent();
        }

        // POST action

        // PUT action

        // DELETE action

    }
}
