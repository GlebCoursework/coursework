using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public virtual EngineDTO Engine { get; set; }
        public virtual GearboxDTO Gearbox { get; set; }
        public virtual InteriorDTO Interior { get; set; }
        public virtual ExteriorDTO Exterior { get; set; }
    }
}
