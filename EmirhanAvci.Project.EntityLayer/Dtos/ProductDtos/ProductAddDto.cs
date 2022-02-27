using EmirhanAvci.Project.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Dtos.ProductDtos
{
    public class ProductAddDto
    {
        [Required(ErrorMessage ="This area is required")]
        [MaxLength(100,ErrorMessage ="This area max length equal to {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This area is required")]
        [MaxLength(500, ErrorMessage = "This area max length equal to {0}")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This area is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "This area is required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "This area is required")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "This area is required")]
        public int ColorId { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
