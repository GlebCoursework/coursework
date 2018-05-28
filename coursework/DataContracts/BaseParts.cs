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
    public class BaseParts //батьківський класс з основними полями на які ссилаються інші класу, в якому данні конвертуються з BLL в WCF
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