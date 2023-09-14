using WebApi.Models;

namespace WebApi.Data
{
    public class DBInitializer
    {
        public static void Initialize(WebApiContext context)
        {

            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }

            var books = new Book[]
            {
              new Book {  Name = "Harry Potter", Issued = false, Author="J.K. Rowling",Genre="Fanstasy"},
              new Book {  Name = "Pride and Prejudice", Issued = false, Author="Jane Austen",Genre="Romance"}

            };

            context.Book.AddRange(books);
            context.SaveChanges();
        }
    }
}
