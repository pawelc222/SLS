using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Input;

namespace SLS.Desktop.ViewModels
{
    class PublishersModel : ViewModel<Controls.Publishers>
    {


        public PublishersModel(Controls.Publishers view)
        {
            View = view;

            initData();
        }

        public ObservableCollection<SLSDesktopServiceProxy.publisher> Data { get; private set; }

        private void initData() {
            Data = new ObservableCollection<SLSDesktopServiceProxy.publisher>();

            var test = new SLSDesktopServiceProxy.publisher();
            test.id = 404;
            test.name = "test";

            Data.Add(test);

        }



    }
}
