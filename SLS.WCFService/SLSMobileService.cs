using SLS.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SLS.WCFService
{
    public class SLSMobileService : ISLSMobileService
    {
        public List<Book> GetBooksForUser(int userId)
        {
            using (var ctx = new SLSEntities())
            {
                List<Book> books = new List<Book>();
                var entityBooks = (from b in ctx.books
                             from bor in b.borrows
                             where bor.user_id_fk == userId
                             select b).ToList();
                if (entityBooks != null)
                {
                    foreach (var entityBook in entityBooks)
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
                        books.Add(book);
                    }
                    return books;
                }
                else
                {
                    throw new FaultException("User have no books borrowed.");
                }

            }
        }

        public bool BorrowBook(int userId, int bookId)
        {
            using (var ctx = new SLSEntities())
            {
                var book = (from b in ctx.books where b.id == bookId select b).FirstOrDefault();
                var user = (from u in ctx.users where u.id == userId select u).FirstOrDefault();
                if (book != null && user != null)
                {
                    if (book.available_copies > 0)
                    {
                        borrow bor = new borrow();
                        bor.book_id_fk = book.id;
                        bor.user_id_fk = user.id;
                        bor.from_date = DateTime.Now.Date;
                        bor.to_date = DateTime.Now.AddDays(30);
                        bor.prolong_cnt = 0;
                        bor.book = book;
                        bor.user = user;
                        book.borrows.Add(bor);
                        book.available_copies -= 1;
                        user.borrows.Add(bor);
                        ctx.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new FaultException("Cannot find the book or user in the database.");
                }
            }
        }

        public bool ReturnBook(int userId, int bookId)
        {
            using (var ctx = new SLSEntities())
            {
                var entityBook = (from b in ctx.books 
                            from borr in b.borrows
                            where b.id == bookId 
                                && borr.user_id_fk == userId 
                            select b).FirstOrDefault();
                var user = (from u in ctx.users where u.id == userId select u).FirstOrDefault();
                var bor = (from b in ctx.borrows 
                              where b.user_id_fk == userId 
                              && b.book_id_fk == bookId 
                              select b).FirstOrDefault();

                if (entityBook != null && user != null)
                {
                     entityBook.borrows.Remove(bor);
                     entityBook.available_copies += 1;
                     user.borrows.Remove(bor);
                     ctx.borrows.Remove(bor);
                     ctx.SaveChanges();
                     return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
