using SLS.Desktop.SLSDesktopServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

            var viewModel = new ViewModels.MainWindowModel(this);
            base.DataContext = viewModel;

        }

        private void toggleMenu_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CloseItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                var treeView = sender as TreeView;
                var item = treeView.SelectedItem as TreeViewItem;
                var itemTag = item.Tag.ToString();
                //var type = Type.GetType("SLS.Desktop.Commands." + item.Tag);
                //Console.WriteLine(type.ToString());
                //ICommand command = Activator.CreateInstance(type) as ICommand;
                ICommand command = DataContext.GetType().GetProperty(itemTag).GetValue(DataContext) as ICommand;
                command.Execute(item);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

                    //if (commandViewModel != null)
                    //{
                    //    var mi = commandViewModel.Command.GetType().GetMethod("Execute");
                    //    mi.Invoke(commandViewModel.Command, new Object[] { null });
                    //}
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    SLSDesktopServiceClient p = new SLSDesktopServiceClient();
        //    p.Open();
        //    try
        //    {
        //        Book book = p.GetBook(Int32.Parse(bookNumberTextbox.Text));
        //        titleLabel.Content = book.title;
        //    } catch (FaultException<Exception> ex) {
        //        MessageBox.Show(ex.Detail.Message);
        //    }
        //    finally
        //    {
        //        p.Close();
        //    }
            
        //}

        
    }
}
