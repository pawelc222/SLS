using SLS.Desktop.SLSDesktopServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS.Desktop
{
    class BusinessDelegate
    {
        private static BusinessDelegate instance;
        private SLSDesktopServiceClient client;

        private BusinessDelegate()
        {
            client = new SLSDesktopServiceClient();
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

        public List<Publisher1> GetAllPublishers()
        {
            return client.GetAllPublishers().ToList();
        }

        public void SavePublisher(Publisher1 publisher)
        {
            client.SavePublisher(publisher);
        }

        public void DeletePublisher(Publisher1 publisher)
        {
            client.DeletePublisher(publisher);
        }
    }
}
