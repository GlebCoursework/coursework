using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public abstract class BaseClass // основний класс запчастин в якому є поля до яких будуть ссилатись інші класи
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
