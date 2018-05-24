using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace coursework.DataContracts
{
    [DataContract]
    public class Engine : BaseParts
    {
        
        [DataMember]
        public int Cylinders { get; set; }

        [DataMember]
        public int HP { get; set; }

        [DataMember]
        public int Torque { get; set; }

        [DataMember]
        public double Liters { get; set; }

        [DataMember]
        public string Type { get; set; }

    }
}