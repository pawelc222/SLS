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
    class MainWindowModel : ViewModel<MainWindow>
    {


        public MainWindowModel(MainWindow view)
        {
            View = view;
            ShowBooks = new Commands.ShowBooks() { View = view };
            ShowCategories = new Commands.ShowCategories() { View = view };
            ShowPublishers = new Commands.ShowPublishers() { View = view };

            initNav();
        }

        public ObservableCollection<TreeViewItem> NavItems { get; private set; }

        public ICommand ShowBooks { get; private set; }
        public ICommand ShowCategories { get; private set; }
        public ICommand ShowPublishers { get; private set; }

        private void initNav() {
            NavItems = new ObservableCollection<TreeViewItem>();

            var tabs = View.tabs.Items;
            foreach (TabItem item in tabs)
            {
                if (item.Header.Equals(""))
                    continue;

                var treeItem = new TreeViewItem();
                treeItem.Header = item.Header;
                treeItem.Tag = "Show" + item.Tag;

                // można też pobierać z Resource
                var subitem = new TreeViewItem();
                subitem.Header = "Dodaj";
                subitem.Tag = "Add" + item.Tag;
                treeItem.Items.Add(subitem);

                NavItems.Add(treeItem);
            }

        }



    }
}
