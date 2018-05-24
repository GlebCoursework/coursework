using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace coursework.DataContracts
{
    [DataContract]
    public class Gearbox : BaseParts
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }
}