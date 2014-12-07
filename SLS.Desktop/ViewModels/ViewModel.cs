using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS.Desktop.ViewModels
{
    public abstract class ViewModel<T> : BindableBase
    {
        public T View { get; protected set; }
    }
}
