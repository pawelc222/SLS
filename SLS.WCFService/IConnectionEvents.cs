using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SLS.WCFService
{
    interface IConnectionEvents
    {
        [OperationContract(IsOneWay = true)]
        void StatusChanged(string newStatus);
    }
}
