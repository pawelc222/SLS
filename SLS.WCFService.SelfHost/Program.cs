using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SLS.WCFService.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost svcHost = null;
            try
            {
                svcHost = new ServiceHost(typeof(SLS.WCFService.Service1));
                svcHost.Open(); Console.WriteLine("\n\nService is Running  at following address");
                Console.WriteLine("\nhttp://localhost:1234/SLSMobile");
                Console.WriteLine("\nnet.tcp://localhost:4567/SLS");
            }
            catch (Exception eX)
            {
                svcHost = null;
                Console.WriteLine("Service can not be started \n\nError Message [" + eX.Message + "]");
                Console.ReadKey();
            } if (svcHost != null)
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                svcHost.Close();
                svcHost = null;
            }            
        }
    }
}
