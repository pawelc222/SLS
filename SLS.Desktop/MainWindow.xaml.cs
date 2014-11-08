using SLS.Desktop.SLSDesktopServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SLS.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SLSDesktopServiceClient p = new SLSDesktopServiceClient();
            p.Open();
            Book book = p.GetBook(Int32.Parse(bookNumberTextbox.Text));
            titleLabel.Content = book.title;
            p.Close();
        }
    }
}
