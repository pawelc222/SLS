using SLS.WCFService.SLS.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLS.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SLSDesktopService : ISLSDesktopService
    {
        public Book GetBook(int bookId)
        {
            using (var ctx = new SLSEntities())
            {
                var entityBook = (from b in ctx.books where b.id == bookId select b).FirstOrDefault();
                if(entityBook != null) 
                {

                    return GetBookFromEntity(entityBook);
                }
                else
                {
                    throw new FaultException("Cannot find the book in the database");
                }

            }
        }

        public List<Book> GetAllBooks()
        {
            using (var ctx = new SLSEntities())
            {
                List<Book> books = new List<Book>();
                var entityBooks = ctx.books.ToList();
                foreach (var b in entityBooks)
                {
                    books.Add(GetBookFromEntity(b));
                }
                return books;
            }
        }

        public List<Book> GetDueBooks()
        {
            using (var ctx = new SLSEntities())
            {
                List<Book> books = new List<Book>();
                var entityBooks = (from b in ctx.books
                                   from bor in b.borrows
                                   where bor.to_date < DateTime.Now//DateTime.Compare(bor.to_date., DateTime.Now.Date) < 0
                                   select b);
                if (entityBooks != null)
                {
                    foreach (var b in entityBooks)
                    {
                        books.Add(GetBookFromEntity(b));
                    }
                    return books;
                }
                else
                {
                    throw new FaultException("There are no due books in the library.");
                }
                
            }
        }

        private Book GetBookFromEntity(book entityBook)
        {
            Book book = new Book();
            book.id = entityBook.id;
            book.isbn = entityBook.isbn;
            book.publish_date = entityBook.publish_date;
            book.publish_city = entityBook.publish_city;
            book.publish_edition = entityBook.publish_edition;
            book.title = entityBook.title;
            book.cover = entityBook.cover;
            book.table_of_contents = entityBook.table_of_contents;
            book.language = entityBook.language;
            book.description = entityBook.description;
            book.available_copies = entityBook.available_copies;
            return book;
        }

    }
}
