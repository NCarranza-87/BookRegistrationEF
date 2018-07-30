using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF
{
    public static class BookDB
    {
        public static List<Book> GetAllBooks()
        {
            var context = new BookContext();
            List<Book> allBooks =
                (from b in context.Book
                 select b).ToList();
            return allBooks;
        }

        /// <summary>
        /// Add a book to the database
        /// </summary>
        /// <param name="b"> the book to be added</param>
        public static void Add(Book b)
        {
            BookContext context = new BookContext();

            //assume Book is valid
            context.Book.Add(b);

            context.SaveChanges();
        }
    }
}
