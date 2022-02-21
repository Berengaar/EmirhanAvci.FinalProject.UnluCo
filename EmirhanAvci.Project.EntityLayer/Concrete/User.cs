using EmirhanAvci.Project.SharedLayer.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Concrete
{
    //Id:int
    public class User : IdentityUser<int>
    {
        public string Picture { get; set; }

        public ICollection<Offer> Offers { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
