using EmirhanAvci.Project.EntityLayer.Authentication;
using EmirhanAvci.Project.SharedLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Concrete
{
    public class Offer:EntityBase,IEntity
    {
        public double? Percent { get; set; }
        public bool IsAccepted { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
