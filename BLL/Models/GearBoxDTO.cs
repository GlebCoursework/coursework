using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class GearboxDTO : BaseClassDTO
    {
        public string Type { get; set; }
        public int Quantity { get; set; }
    }
}
