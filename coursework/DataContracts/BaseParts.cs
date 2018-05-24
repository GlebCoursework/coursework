using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace coursework.DataContracts
{
    [DataContract]
    [KnownType(typeof(Engine))]
    [KnownType(typeof(Gearbox))]
    [KnownType(typeof(Interior))]
    [KnownType(typeof(Exterior))]
    public class BaseParts
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Producer { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public virtual ICollection<Car> Cars { get; set; }

    }
}