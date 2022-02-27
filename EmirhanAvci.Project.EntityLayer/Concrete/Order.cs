using EmirhanAvci.Project.EntityLayer.Authentication;
using EmirhanAvci.Project.SharedLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Concrete
{
    public class Order:EntityBase,IEntity
    {
        public string OrderCode { get; set; }
        public bool IsBuy { get; set; } // Satın alma - satma
        public double AcceptOfferPrice { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
