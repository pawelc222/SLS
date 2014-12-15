using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SLS.Desktop
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    class SLSDesktopServiceCallback : SLSDesktopServiceProxy.ISLSDesktopServiceCallback
    {
        public void StatusChanged(string newStatus)
        {
            BusinessDelegate.Instance.OperationState = newStatus;
        }
    }
}
