﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        /*
         * EF will track an object if you pull it
         * out of the database and then do modifications
         * */
        public static void Update(Book b)
        {
            var context = new BookContext();

            //get book from DB
            Book originalBook =
                context.Book.Find(b.ISBN);

            //update any changed properties
            originalBook.Price = b.Price;
            originalBook.Title = b.Title;

            context.SaveChanges();
        }

        public static void UpdateAlternate(Book b)
        {
            var context = new BookContext();

            //add Book to object to current context
            context.Book.Add(b);

            //Let EF know the book already exists
            context.Entry(b).State =
                EntityState.Modified;

            context.SaveChanges();
        }

        
        public static void Delete(Book b)
        {
            var context = new BookContext();
            context.Book.Add(b);

            //mark the Book as deleted
            context.Entry(b).State = 
                EntityState.Deleted;

            context.SaveChanges();
        }

        //Connected scenario where the DB Context
        //track entities in memory
        public static void Delete(string isbn)
        {
            var context = new BookContext();

            //pull Book from DB to make EF track it
            Book BookToDelete =
                context.Book.Find(isbn);

            //mark Book as deleted
            context.Book.Remove(BookToDelete);

            //send delete query to DB
            context.SaveChanges();
        }
    }
}
