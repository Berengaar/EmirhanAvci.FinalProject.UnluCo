using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Dtos.ProductDtos
{
    public class ProductUploadDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
