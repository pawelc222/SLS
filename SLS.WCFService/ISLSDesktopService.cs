using SLS.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLS.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IConnectionEvents), SessionMode=SessionMode.Required)]
    public interface ISLSDesktopService
    {
        [OperationContract]
        [FaultContract(typeof(BookNotFoundFault))]
        Book GetBook(int bookId);

        [OperationContract]
        List<Book> GetAllBooks();

        [OperationContract]
        List<Book> GetDueBooks();

        [OperationContract]
        [FaultContract(typeof(EntityCouldNotBeAdded))]
        bool AddAuthor(author authorToAdd);

        [OperationContract]
        [FaultContract(typeof(EntityCouldNotBeAdded))]
        int SaveBook(Book bookToAdd);

        [OperationContract]
        bool DeleteBook(Book bookToDelete);

        [OperationContract]
        void SendPushNotification(string NotificationContent);

        [OperationContract]
        List<Publisher> GetAllPublishers();

        [OperationContract]
        int SavePublisher(Publisher publisherToSave);

        [OperationContract]
        bool DeletePublisher(Publisher publisherToDelete);

        [OperationContract]
        void SubscribeConnectionEvent();
    }
}
