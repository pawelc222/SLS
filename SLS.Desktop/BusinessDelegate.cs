using SLS.Desktop.SLSDesktopServiceProxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SLS.Desktop
{
    class BusinessDelegate : INotifyPropertyChanged
    {
        private static BusinessDelegate instance;
        private SLSDesktopServiceClient client;

        private string operationState;
        public string OperationState
        {
            get { return operationState;  }
            set
            {
                operationState = value;
                RaisePropertyChanged("OperationState");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string ServerConnectionState { get; set; }

        private BusinessDelegate()
        {
            client = new SLSDesktopServiceClient(new InstanceContext(new SLSDesktopServiceCallback()));
            SubscribeConnectionEvent();
            OperationState = "Bezczynny";
            ServerConnectionState = "Połączony";
        }

        public static BusinessDelegate Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BusinessDelegate();
                }
                return instance;
            }
        }

        public List<Book> GetAllBooks()
        {
            return client.GetAllBooks().ToList();
        }

        public int SaveBook(Book book)
        {
            return client.SaveBook(book);
        }

        public void DeleteBook(Book book)
        {
            client.DeleteBook(book);
        }

        public List<Publisher1> GetAllPublishers()
        {
            return client.GetAllPublishers().ToList();
        }

        public int SavePublisher(Publisher1 publisher)
        {
            return client.SavePublisher(publisher);
        }

        public void DeletePublisher(Publisher1 publisher)
        {
            client.DeletePublisher(publisher);
        }

        public void SendPushNotification(string content)
        {
            client.SendPushNotification(content);
        }

        public void SubscribeConnectionEvent()
        {
            client.SubscribeConnectionEvent();
        }
    }
}
