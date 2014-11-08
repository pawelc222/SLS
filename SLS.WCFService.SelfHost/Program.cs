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
                //svcHostDesktop.Opened += new EventHandler(onSvcHostDesktopOpened);
                svcHostDesktop.Closed += new EventHandler(onSvcHostDesktopClosed);
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
            }
            
            if (svcHostDesktop != null)
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                svcHostDesktop.Close();
                svcHostDesktop = null;
                svcHostMobile.Close();
                svcHostMobile = null;
            }            
        }

        private static void onSvcHostDesktopOpened(object sender, EventArgs e)
        {
            Console.WriteLine("\nDesktop Service opened");

            // init
            using (var ctx = new SLSEntities())
            {
                try
                {
                    var allTables = new List<String>
                    {
                        "book_authors",
                        "book_categories",
                        "borrows",
                        "reservations",
                        "authors",
                        "books",
                        "publishers",
                        "categories",
                        "users",
                        "roles"
                    };

                    var tablesWithId = new List<String>
                    {
                        "borrows",
                        "reservations",
                        "authors",
                        "books",
                        "publishers",
                        "categories",
                        "users",
                        "roles"
                    };

                    /* usunięcie zawartości bazy danych */
                    var objCtx = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)ctx).ObjectContext;

                    foreach (var name in allTables)
                    {
                        objCtx.ExecuteStoreCommand("DELETE FROM [" + name + "]");
                    }

                    foreach (var name in tablesWithId)
                    {
                        objCtx.ExecuteStoreCommand("DBCC CHECKIDENT ('" + name + "', RESEED, 0)");
                    }

                    /* zapisanie domyślnych wartości */
                    var roles = new List<role>
                    {
                        new role() {name="Czytelnik", description="Czytelnicy"},
                        new role() {name="Bibliotekarz", description="Bibliotekarze"},
                    };
                    ctx.roles.AddRange(roles);

                    var users = new List<user>
                    {
                        new user() {role=roles[0], login="janek", email="janek@gmail.com", firstname="Jan", surname="Kowalski", phone=123234345, passwd="qwerty", incorrect_login_cnt=2},
                        new user() {role=roles[1], login="anetka", email="aneta@gmail.com", firstname="Aneta", surname="Kowalska", phone=555666123, passwd="1234", incorrect_login_cnt=0},
                    };
                    ctx.users.AddRange(users);

                    var categories = new List<category>
                    {
                        new category() {name="Komedia"},
                        new category() {name="Beletrystyka"},
                        new category() {name="Fantastyka"},
                        new category() {name="Historyczne"},
                        new category() {name="Detektywistyczne"},
                        new category() {name="Przygodowe"},
                        new category() {name="Dla dzieci"},
                        new category() {name="Bestseller"},
                        new category() {name="Przewodniki"}
                    };
                    ctx.categories.AddRange(categories);

                    var publishers = new List<publisher>
                    {
                        new publisher() {name="Ossolineum"},
                        new publisher() {name="Addison-Wesley"},
                        new publisher() {name="Apress"},
                        new publisher() {name="Helion"},
                        new publisher() {name="Prószyński i S-ka"},
                    };
                    ctx.publishers.AddRange(publishers);

                    var authors = new List<author>
                    {
                        new author() {firstname="Stanisław", surname="Lem", date_of_birth=new DateTime(1921, 9, 12), date_of_death=new DateTime(2006, 3, 27)},
                        new author() {firstname="Wojciech", surname="Sumliński", date_of_birth=new DateTime(1969, 4, 15)},
                    };
                    ctx.authors.AddRange(authors);

                    ctx.SaveChanges();

                    Console.WriteLine("\nDatabase was filled with default values (fixtures).");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError occurs when filling database with default values (fixtures).");
                    Console.WriteLine(ex.ToString());
                }
           }
        }

        private static void onSvcHostDesktopClosed(object sender, EventArgs e)
        {
            Console.WriteLine("\nDesktop Service closed");
        }

    }
}
