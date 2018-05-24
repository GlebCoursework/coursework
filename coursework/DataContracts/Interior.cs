using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace coursework.DataContracts
{
    [DataContract]
    public class Interior : BaseParts
    {
        [DataMember]
        public string Colour { get; set; }

        [DataMember]
        public string Material { get; set; }
    }
}