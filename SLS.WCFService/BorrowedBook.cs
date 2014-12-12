using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SLS.WCFService
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class BorrowedBook
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string isbn { get; set; }
        
        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string cover { get; set; }

        [DataMember]
        public string table_of_contents { get; set; }

        [DataMember]
        public string language { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public DateTime ToDate { get; set; }
    }

    [DataContract]
    public class AuthBook
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
    }
}


