using EmirhanAvci.Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Dtos
{
    public class ProductAddDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
       
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int UserId { get; set; }
    }
}
