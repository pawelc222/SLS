﻿using SLS.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SLS.WCFService
{
    [ServiceContract]
    public interface ISLSMobileService
    {
        [OperationContract]
        List<BorrowedBook> GetBooksForUser(int userId);
        
        [OperationContract]
        bool BorrowBook(int userId, int bookId);

        [OperationContract]
        bool ReturnBook(int userId, int bookId);

        [OperationContract]
        void AddPushNotificationService(string address);
    }
}
