using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public abstract class BaseClassDTO //батьківський класс з основними полями на які ссилаються інші класу, в якому данні конвертуються з DAL в BLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<CarDTO>Cars { get; set; }
    }
}
