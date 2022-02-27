using EmirhanAvci.Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [MaxLength(100, ErrorMessage = "{0} can not exceed {1} characters")]
        [MinLength(2, ErrorMessage = "{0} can not less than {1} characters")]
        public string Name { get; set; }

        [DisplayName("Product Description")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [MaxLength(400, ErrorMessage = "{0} can not exceed {1} characters")]
        [MinLength(2, ErrorMessage = "{0} can not less than {1} characters")]
        public string Description { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [Range(0, 100000, ErrorMessage = "{0} range must be {1}-{2}")]
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
    }
}
