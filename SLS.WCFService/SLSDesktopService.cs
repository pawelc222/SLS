using SLS.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLS.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.PerSession)]
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
                    BookNotFoundFault fault = new BookNotFoundFault();
                    fault.Result = false;
                    fault.Message = "Book not found";
                    fault.Description = "Requested book with id: " + bookId.ToString() + " is not found in database.";
                    throw new FaultException<BookNotFoundFault>(fault);
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
                    BookNotFoundFault fault = new BookNotFoundFault();
                    fault.Result = false;
                    fault.Message = "Books not found";
                    fault.Description = "There are no due books in the library.";
                    throw new FaultException<BookNotFoundFault>(fault);
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



        public bool AddAuthor(author authorToAdd)
        {
            bool result;
            using (var ctx = new SLSEntities())
            {
                try
                {
                    ctx.authors.Add(authorToAdd);
                    ctx.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    EntityCouldNotBeAdded fault = new EntityCouldNotBeAdded();
                    fault.Result = false;
                    fault.Message = "Author couldn't be added";
                    fault.Description = "Error details: " + ex.ToString();
                    throw new FaultException<EntityCouldNotBeAdded>(fault);
                }
            }
            return result;
        }


        public bool AddBook(book bookToAdd, List<author> authors)
        {
            bool result;
            using (var ctx = new SLSEntities())
            {
                try
                {
                    bookToAdd.book_authors = new List<book_authors>();
                    int order = 1;
                    foreach (author bookAuthor in authors)                        
                    {
                        var auth = (from a in ctx.authors where a.id == bookAuthor.id select a).FirstOrDefault();
                        bookToAdd.book_authors.Add(new book_authors { author = auth, book = bookToAdd, ord = order++ });
                    }
                    ctx.books.Add(bookToAdd);
                    ctx.SaveChanges();

                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    EntityCouldNotBeAdded fault = new EntityCouldNotBeAdded();
                    fault.Result = false;
                    fault.Message = "Book couldn't be added";
                    fault.Description = "Error details: " + ex.ToString();
                    throw new FaultException<EntityCouldNotBeAdded>(fault);
                }
            }
            return result;
        }
    }
}
