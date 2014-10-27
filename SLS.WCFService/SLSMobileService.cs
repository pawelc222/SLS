using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLS.WCFService
{
    public class SLSMobileService : ISLSMobileService
    {
        public string GetDataMobile(int value)
        {
            return value.ToString();
        }
    }
}
