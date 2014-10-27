using SLS.WCFService.SLS.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLS.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISLSDesktopService
    {
        [OperationContract]
        Book GetBook(int bookId);

        [OperationContract]
        List<Book> GetAllBooks();

        [OperationContract]
        List<Book> GetDueBooks();


        // TODO: Add your service operations here
    }
}
