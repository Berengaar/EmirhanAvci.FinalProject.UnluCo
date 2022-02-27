using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Dtos.OrderDtos
{
    public class OrderAddDto
    {
        public int ProductId { get; set; }
        public string OrderCode { get; set; }
        public bool IsBuy { get; set; } // Satın alma - satma
        public double AcceptOfferPrice { get; set; }
        public int UserId { get; set; }

    }
}
