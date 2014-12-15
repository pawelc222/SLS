using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Input;
using SLS.Desktop.SLSDesktopServiceProxy;

namespace SLS.Desktop.ViewModels
{
    public class BooksModel : ViewModel<Controls.Books>
    {

        public BooksModel(Controls.Books view)
        {
            View = view;

            initData();
        }


        public ObservableCollection<SLSDesktopServiceProxy.book1> Data { get; set; }

        public void AddEntity(SLSDesktopServiceProxy.book1 entity)
        {
            Data.Add(entity);
        }

        private void initData() {
            Data = new ObservableCollection<SLSDesktopServiceProxy.book1>();

            List<Book> books = BusinessDelegate.Instance.GetAllBooks();

            foreach (Book b in books)
            {
                book1 book = new SLSDesktopServiceProxy.book1 { id = b.id, title = b.title, isbn = b.isbn, description = b.description};
                Data.Add(book);
                book.PropertyChanged += Item_PropertyChanged;
            }

            Data.CollectionChanged += Data_CollectionChanged;

        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            Console.WriteLine("Item_PropertyChanged");
            Console.WriteLine(sender.ToString());
            Console.WriteLine(eventArgs.ToString());
            Console.WriteLine("---");

            Book b = convertEntityToBook((book1)sender);
            BusinessDelegate.Instance.SaveBook(b);
        }

        private Book convertEntityToBook(book1 book)
        {
            Book b = new Book();
            b.id = book.id;
            b.title = book.title;
            b.isbn = book.isbn;
            b.description = book.description;
            return b;
        }


        void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs eventArgs)
        {
            Console.WriteLine("Data_CollectionChanged");
            Console.WriteLine(sender.ToString());
            Console.WriteLine(eventArgs.ToString());
            Console.WriteLine("---");

            IList list = null;
            Book b = null;
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    book1 newBook = (book1)eventArgs.NewItems[0];
                    b = convertEntityToBook(newBook);
                    int id = BusinessDelegate.Instance.SaveBook(b);
                    newBook.id = id;

                    Console.WriteLine("dodanie encji na serwerze");
                    list = eventArgs.NewItems;

                    BusinessDelegate.Instance.SendPushNotification("Nowa książka w bibliotece");
                    break;  

                case NotifyCollectionChangedAction.Remove:
                    book1 oldBook = (book1)eventArgs.OldItems[0];
                    b = convertEntityToBook(oldBook);
                    BusinessDelegate.Instance.DeleteBook(b);

                    Console.WriteLine("usunięcie encji na serwerze");
                    list = eventArgs.OldItems;

                    break;

                default:
                    Console.WriteLine("Data_CollectionChanged: not supported action: " + eventArgs.Action.ToString());
                    break;
            }
        }



    }
}
