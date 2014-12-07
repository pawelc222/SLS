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

namespace SLS.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for Publishers.xaml
    /// </summary>
    public partial class Publishers : UserControl
    {
        public Publishers()
        {
            InitializeComponent();

            ViewModel = new ViewModels.PublishersModel(this);
            base.DataContext = ViewModel;
        }

        public ViewModels.PublishersModel ViewModel { get; set; }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("DataGrid_Loaded");
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Console.WriteLine("DataGrid_CellEditEnding");
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var entity = new SLSDesktopServiceProxy.publisher {id = -1, name = PublisherName.Text};
            PublisherName.Text = "";
            ViewModel.AddEntity(entity);
        }

        private void RemoveEntity_Onclick(object sender, RoutedEventArgs e)
        {
            try
            {
                var entity = DataGrid.SelectedItem as SLSDesktopServiceProxy.publisher;
                var id = entity.id;
                Console.WriteLine("RemoveEntity id: " + id.ToString());
                ViewModel.Data.Remove(entity);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
