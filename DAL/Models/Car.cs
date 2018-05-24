using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public virtual Engine Engine { get; set; }
        public virtual Gearbox Gearbox { get; set; }
        public virtual Interior Interior { get; set; }
        public virtual Exterior Exterior { get; set; }
    }
}
