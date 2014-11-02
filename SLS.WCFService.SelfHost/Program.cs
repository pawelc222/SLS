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

            ServiceHost svcHostDesktop = null;
            ServiceHost svcHostMobile = null;
            try
            {                
                svcHostDesktop = new ServiceHost(typeof(SLS.WCFService.SLSDesktopService));
                svcHostDesktop.Open(); 
                Console.WriteLine("\n\nSLS Service Desktop is Running  at following address");
                Console.WriteLine("\nnet.tcp://localhost:4567/SLS");
                
                svcHostMobile = new ServiceHost(typeof(SLS.WCFService.SLSMobileService));
                svcHostMobile.Open(); 
                Console.WriteLine("\n\nSLS Service Mobile is Running  at following address");
                Console.WriteLine("\nhttp://localhost:1234/SLSMobile");
                
            }
            catch (Exception eX)
            {
                svcHostDesktop = null;
                svcHostMobile = null;
                Console.WriteLine("Service can not be started \n\nError Message [" + eX.Message + "]");
                Console.ReadKey();
            } if (svcHostDesktop != null)
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                svcHostDesktop.Close();
                svcHostDesktop = null;
                svcHostMobile.Close();
                svcHostMobile = null;
            }            
        }
    }
}
