using EmirhanAvci.Project.SharedLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Concrete
{
    public class Brand:EntityBase,IEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
