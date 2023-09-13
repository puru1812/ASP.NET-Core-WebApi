using System.Linq;
using System.Xml.Linq;
using WebApi.Models;
namespace WebApi.Services
{
    public static class BookService
    {
        static List<Book> Books { get; }
        static int nextId = 3;
        static BookService()
        {
            Books = new List<Book>
        {
            new Book { Id = 1, Name = "Harry Potter", Issued = false, Author="J.K. Rowling",Genre="Fanstasy"},
              new Book { Id = 2, Name = "Pride and Prejudice", Issued = false, Author="Jane Austen",Genre="Romance"}
        };
        }

        public static List<Book> GetAll() => Books;

        public static Book? Get(int id) => Books.FirstOrDefault(p => p.Id == id);

        public static void Add(Book book)
        {
            book.Id = nextId++;
            Books.Add(book);
        }

        public static void Delete(int id)
        {
            var book = Get(id);
            if (book is null)
                return;

            Books.Remove(book);
        }

        public static void Update(Book book)
        {
            var index = Books.FindIndex(p => p.Id == book.Id);
            if (index == -1)
                return;

            Books[index] = book;
        }
    }
}
