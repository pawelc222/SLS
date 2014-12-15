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
    public class PublishersModel : ViewModel<Controls.Publishers>
    {

        public PublishersModel(Controls.Publishers view)
        {
            View = view;

            initData();
        }


        public ObservableCollection<SLSDesktopServiceProxy.publisher> Data { get; set; }

        public void AddEntity(SLSDesktopServiceProxy.publisher entity)
        {
            Data.Add(entity);
        }

        private void initData() {
            Data = new ObservableCollection<SLSDesktopServiceProxy.publisher>();

            updatePublishers();
        }

        public void updatePublishers()
        {
            List<Publisher1> publishers = BusinessDelegate.Instance.GetAllPublishers();

            foreach (Publisher1 p in publishers)
            {
                var pub = new SLSDesktopServiceProxy.publisher { id = p.id, name = p.name };
                Data.Add(pub);
                pub.PropertyChanged += Item_PropertyChanged;
            }

            Data.CollectionChanged += Data_CollectionChanged;
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            Console.WriteLine("Item_PropertyChanged");
            Console.WriteLine(sender.ToString());
            Console.WriteLine(eventArgs.ToString());
            Console.WriteLine("---");

            Publisher1 p = new Publisher1();
            publisher newP = (publisher)sender;
            p.id = newP.id;
            p.name = newP.name;
            BusinessDelegate.Instance.SavePublisher(p);
        }


        void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs eventArgs)
        {
            Console.WriteLine("Data_CollectionChanged");
            Console.WriteLine(sender.ToString());
            Console.WriteLine(eventArgs.ToString());
            Console.WriteLine("---");

            IList list = null;
            Publisher1 p = null;
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    p = new Publisher1();
                    publisher newP = (publisher)eventArgs.NewItems[0];
                    p.name = newP.name;
                    int id = BusinessDelegate.Instance.SavePublisher(p);
                    newP.id = id;
                    Console.WriteLine("dodanie encji na serwerze");
                    list = eventArgs.NewItems;

                    break;  

                case NotifyCollectionChangedAction.Remove:
                    p = new Publisher1();
                    publisher delP = (publisher)eventArgs.OldItems[0];
                    p.id = delP.id;
                    p.name = delP.name;
                    BusinessDelegate.Instance.DeletePublisher(p);
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
