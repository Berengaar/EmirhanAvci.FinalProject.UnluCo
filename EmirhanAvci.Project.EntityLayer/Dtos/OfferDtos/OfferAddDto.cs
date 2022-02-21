using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Dtos.OfferDtos
{
    public class OfferAddDto
    {
        public double? Percent { get; set; }
        public bool IsAccepted { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
