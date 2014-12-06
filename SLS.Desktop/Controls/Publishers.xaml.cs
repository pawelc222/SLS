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

            var viewModel = new ViewModels.PublishersModel(this);
            base.DataContext = viewModel;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
