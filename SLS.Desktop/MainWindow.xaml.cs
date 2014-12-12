using SLS.Desktop.SLSDesktopServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using PropertyTools.Wpf;
using SLS.Desktop.Preferences;

namespace SLS.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /**
         * @source http://stackoverflow.com/a/5041110/1936631
         */
        public static string GetAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
        {
            T attribute = (T)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(T));
            return value.Invoke(attribute);
        }

        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new ViewModels.MainWindowModel(this);
            base.DataContext = viewModel;

            Title = GetAssemblyAttribute<AssemblyTitleAttribute>(a => a.Title);
            Icon = new BitmapImage(new Uri(@"pack://application:,,,/SLS.Desktop;component/images/Books-icon.png"));
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

        private void Preferences_OnClick(object sender, RoutedEventArgs e)
        {
            var dlg = new PropertyDialog() { Owner = this };
            var options = new SettingsModel();

            dlg.DataContext = options;
            dlg.Title = "Ustawienia";
            dlg.CanApply = false;

            var showDialog = dlg.ShowDialog();
            if (showDialog != null && showDialog.Value)
            {
                options.Save();
            }
        }

        private void About_OnClick(object sender, RoutedEventArgs e)
        {
            var dlg = new AboutDialog(this);
            dlg.Title = "O programie";
            dlg.UpdateStatus = "Korzystasz z najnowszej wersji programu.";
            dlg.Image = new BitmapImage(new Uri(@"pack://application:,,,/SLS.Desktop;component/images/Books-icon.png"));
            dlg.Width = 300;
            dlg.MaxWidth = 300;
            dlg.ShowDialog(); 
        }

        private void Notification_OnClick(object sender, RoutedEventArgs e)
        {
            SLSDesktopServiceClient client = new SLSDesktopServiceClient();
            client.Open();
            client.SendPushNotification("Nowa książka w bibliotece");
            client.Close();
        }
    }
}
