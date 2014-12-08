using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using SLS.Desktop.Preferences;
using SLS.Desktop.SLSDesktopServiceProxy;

namespace SLS.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for BookDetails.xaml
    /// </summary>
    public partial class BookDetails : UserControl
    {
        public BookDetails()
        {
            InitializeComponent();

            DependencyPropertyDescriptor.FromProperty(BookDetails.ViewModeProperty, typeof(BookDetails))
                .AddValueChanged(this, (s, e) =>
                {
                    Console.WriteLine("ViewMode: " + ViewMode.ToString());
                    AllowEdit = !(ViewMode);
                });
            DependencyPropertyDescriptor.FromProperty(BookDetails.AllowEditProperty, typeof(BookDetails))
                .AddValueChanged(this, (s, e) =>
                {
                    Console.WriteLine("AllowEdit: " + AllowEdit.ToString());
                });
            DependencyPropertyDescriptor.FromProperty(BookDetails.BookProperty, typeof(BookDetails))
                .AddValueChanged(this, (s, e) =>
                {
                    Console.WriteLine("BookDetails: book has been changed.");
                });

            Reset();
            DataContext = this;

            ViewModel = new ViewModels.BookDetailsModel(this);
        }

        public ViewModels.BookDetailsModel ViewModel { get; set; }

        public void Reset()
        {
            Book = new book1();
        }

        public static readonly DependencyProperty ViewModeProperty = DependencyProperty.Register("ViewMode", typeof(bool), typeof(BookDetails),
            new UIPropertyMetadata(true));
        public static readonly DependencyProperty AllowEditProperty = DependencyProperty.Register("AllowEdit", typeof(bool), typeof(BookDetails),
            new UIPropertyMetadata(null));
        public static readonly DependencyProperty BookProperty = DependencyProperty.Register("Book", typeof(book1),
            typeof(BookDetails), new UIPropertyMetadata(null));

        public bool ViewMode
        {
            get { return (bool)GetValue(ViewModeProperty); }
            set {SetValue(ViewModeProperty, value); }
        }

        public bool AllowEdit
        {
            get { return (bool)GetValue(AllowEditProperty); }
            set { SetValue(AllowEditProperty, value); }
        }

        public book1 Book
        {
            get { return (book1)GetValue(BookProperty); }
            set { SetValue(BookProperty, value); }
        }
    }
}
