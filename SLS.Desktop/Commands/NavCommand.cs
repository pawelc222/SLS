using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SLS.Desktop.Commands
{
    class NavCommand : ICommand
    {
        public readonly String TabTag;

        public MainWindow View
        {
            get;
            set;
        }


        public NavCommand(String tag)
        {
            TabTag = tag;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public void Execute(object parameter)
        {
            try
            {
                //var treeItem = parameter as TreeViewItem;
                TabItem tab = (from TabItem item in View.tabs.Items
                               where item.Tag.Equals(TabTag)
                               select item).FirstOrDefault();
                View.tabs.SelectedItem = tab;
            }
            catch (NullReferenceException ex)
            {

            }
        }
    }
}
