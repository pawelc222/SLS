using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SLS.WCFService
{
    [ServiceContract]
    public interface ISLSMobileService
    {
        [OperationContract]
        string GetDataMobile(int value);
    }
}
