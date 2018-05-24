using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace coursework.DataContracts
{
    [DataContract]
    public class Car
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public virtual Engine Engine { get; set; }

        [DataMember]
        public virtual Gearbox Gearbox { get; set; }

        [DataMember]
        public virtual Interior Interior { get; set; }

        [DataMember]
        public virtual Exterior Exterior { get; set; }
    }
}