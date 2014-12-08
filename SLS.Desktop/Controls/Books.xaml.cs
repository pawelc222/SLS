using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SLS.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : UserControl
    {
        public Books()
        {
            InitializeComponent();
            ViewModel = new ViewModels.BooksModel(this);
            base.DataContext = ViewModel;
        }

        public ViewModels.BooksModel ViewModel { get; set; }

        private void BooksGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("BooksGrid_OnLoaded");
        }

        private void RemoveEntity_Onclick(object sender, RoutedEventArgs e)
        {
            try
            {
                var entity = BooksGrid.SelectedItem as SLSDesktopServiceProxy.book1;
                var id = entity.id;
                Console.WriteLine("RemoveEntity id: " + id.ToString());
                ViewModel.Data.Remove(entity);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddBook_OnClick(object sender, RoutedEventArgs e)
        {
            var book = NewBook.Book;
            book.id = mockIdCounter++;
            Console.WriteLine("AddBook, title: " + book.title);
            ViewModel.Data.Add(book);

            NewBook.Reset();
        }

        static private int mockIdCounter = 10;
    }
}
