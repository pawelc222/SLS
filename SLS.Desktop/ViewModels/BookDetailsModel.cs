using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Input;

namespace SLS.Desktop.ViewModels
{
    public class BookDetailsModel : ViewModel<Controls.BookDetails>
    {

        public BookDetailsModel(Controls.BookDetails view)
        {
            View = view;

            initData();
        }


        public ObservableCollection<SLSDesktopServiceProxy.publisher> Publishers { get; set; }

        private void initData() {
            Publishers = new ObservableCollection<SLSDesktopServiceProxy.publisher>();

            //@todo: pobranie danych
            var test = new SLSDesktopServiceProxy.publisher {id = 404, name = "Helion"};
            var test2 = new SLSDesktopServiceProxy.publisher { id = 405, name = "Addison-Wesley" };
            Publishers.Add(test);
            Publishers.Add(test2);
        }


    }
}
