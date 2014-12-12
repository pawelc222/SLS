using SLS.WCFService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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


        public void SendPushNotification(string NotificationContent)
        {
            try
             {
                 // Get the URI that the Microsoft Push Notification Service returns to the Push Client when creating a notification channel.
                 // Normally, a web service would listen for URIs coming from the web client and maintain a list of URIs to send
                 // notifications out to.

                 //tu podać adres serwisu przysłany
                 string subscriptionUri = Properties.Settings.Default.PushNotifocationServiceURI;
                

                 HttpWebRequest sendNotificationRequest = (HttpWebRequest)WebRequest.Create(subscriptionUri);

                 // Create an HTTPWebRequest that posts the Tile notification to the Microsoft Push Notification Service.
                 // HTTP POST is the only method allowed to send the notification.
                 sendNotificationRequest.Method = "POST";

                 // The optional custom header X-MessageID uniquely identifies a notification message. 
                 // If it is present, the same value is returned in the notification response. It must be a string that contains a UUID.
                 // sendNotificationRequest.Headers.Add("X-MessageID", "<UUID>");

                 // Create the Tile message.
                 Random r = new Random();
                 string tileMessage = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                 "<wp:Notification xmlns:wp=\"WPNotification\">" +
                     "<wp:Tile>" +
                       "<wp:BackgroundImage>" + "Background.png" + "</wp:BackgroundImage>" +
                       "<wp:Count>" + r.Next(1,10) + "</wp:Count>" +
                       "<wp:Title>" + "SLS Mobile" + "</wp:Title>" +
                       "<wp:BackBackgroundImage>" + "Tileback.png" + "</wp:BackBackgroundImage>" +
                       "<wp:BackTitle>" + "Notification" + "</wp:BackTitle>" +
                       "<wp:BackContent>" + NotificationContent + "</wp:BackContent>" +
                    "</wp:Tile> " +
                 "</wp:Notification>";

                 // Set the notification payload to send.
                 byte[] notificationMessage = System.Text.Encoding.UTF8.GetBytes(tileMessage);

                 // Set the web request content length.
                 sendNotificationRequest.ContentLength = notificationMessage.Length;
                 sendNotificationRequest.ContentType = "text/xml";
                 sendNotificationRequest.Headers.Add("X-WindowsPhone-Target", "token");
                 sendNotificationRequest.Headers.Add("X-NotificationClass", "1");


                 using (Stream requestStream = sendNotificationRequest.GetRequestStream())
                 {
                     requestStream.Write(notificationMessage, 0, notificationMessage.Length);
                 }

                 // Send the notification and get the response.
                 HttpWebResponse response = (HttpWebResponse)sendNotificationRequest.GetResponse();
                 string notificationStatus = response.Headers["X-NotificationStatus"];
                 string notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
                 string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];

                 // Display the response from the Microsoft Push Notification Service.  
                 // Normally, error handling code would be here. In the real world, because data connections are not always available,
                 // notifications may need to be throttled back if the device cannot be reached.
                 Console.WriteLine(notificationStatus + " | " + deviceConnectionStatus + " | " + notificationChannelStatus);
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Exception caught sending update: " + ex.ToString());
             }
         
        }


        public List<Publisher> GetAllPublishers()
        {
            using (var ctx = new SLSEntities())
            {
                var entityPublishers = ctx.publishers.ToList();
                List<Publisher> publishers = new List<Publisher>();
                foreach(var p in entityPublishers)
                {
                    Publisher pub = new Publisher();
                    pub.id = p.id;
                    pub.name = p.name;
                    publishers.Add(pub);
                }
                return publishers;
            }
        }

        public bool SavePublisher(Publisher publisherToSave)
        {
            bool result;
            using (var ctx = new SLSEntities())
            {
                try
                {
                    //var entityPublisher = (from b in ctx.publishers where b.id == publisherToSave.id select b).FirstOrDefault();
                    var entityPublisher = new publisher();
                    entityPublisher.name = publisherToSave.name;
                    ctx.publishers.Add(entityPublisher);
                    ctx.SaveChanges();

                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    EntityCouldNotBeAdded fault = new EntityCouldNotBeAdded();
                    fault.Result = false;
                    fault.Message = "Publisher couldn't be added";
                    fault.Description = "Error details: " + ex.ToString();
                    throw new FaultException<EntityCouldNotBeAdded>(fault);
                }
            }
            return result;
        }


        public bool DeletePublisher(Publisher publisherToDelete)
        {
            /*bool result;
            using (var ctx = new SLSEntities())
            {
                try
                {
                    ctx.publishers.Remove(publisherToDelete);
                    ctx.SaveChanges();

                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    EntityCouldNotBeAdded fault = new EntityCouldNotBeAdded();
                    fault.Result = false;
                    fault.Message = "Publisher couldn't be added";
                    fault.Description = "Error details: " + ex.ToString();
                    throw new FaultException<EntityCouldNotBeAdded>(fault);
                }
            }
            return result;*/
            return true;
        }
    }
}
