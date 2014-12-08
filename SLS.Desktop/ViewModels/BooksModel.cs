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

            //@todo: pobranie danych
            var test = new SLSDesktopServiceProxy.book1 { id = 404, title = "tytuł #1" };
            var test2 = new SLSDesktopServiceProxy.book1 { id = 405, title = "tytuł #2" };
            Data.Add(test);
            Data.Add(test2);
            test.PropertyChanged += Item_PropertyChanged;
            test2.PropertyChanged += Item_PropertyChanged;

            //
            Data.CollectionChanged += Data_CollectionChanged;

        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            Console.WriteLine("Item_PropertyChanged");
            Console.WriteLine(sender.ToString());
            Console.WriteLine(eventArgs.ToString());
            Console.WriteLine("---");

            //@todo: przesłanie zmienionej encji na serwer
            // buforowanie zmian
            // rzutowanie sender na publisher
        }


        void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs eventArgs)
        {
            Console.WriteLine("Data_CollectionChanged");
            Console.WriteLine(sender.ToString());
            Console.WriteLine(eventArgs.ToString());
            Console.WriteLine("---");

            IList list = null;
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    //@todo: dodanie encji na serwerze
                    Console.WriteLine("dodanie encji na serwerze");
                    list = eventArgs.NewItems;

                    break;  

                case NotifyCollectionChangedAction.Remove:
                    //@todo: usunięcie encji na serwerze
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
