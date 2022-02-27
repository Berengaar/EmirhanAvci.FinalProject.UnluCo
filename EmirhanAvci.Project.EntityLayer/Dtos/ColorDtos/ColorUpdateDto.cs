using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Dtos.ColorDtos
{
    public class ColorUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Color Name")]
        [Required(ErrorMessage = "{0} can not be empty.")]
        [MaxLength(100, ErrorMessage = "{0} can not exceed {1} characters")]
        [MinLength(2, ErrorMessage = "{0} can not less than {1} characters")]
        public string Name { get; set; }

        [DisplayName("Color Description")]
        [Required(ErrorMessage = "{0} can not be empty.")]
        [MaxLength(250, ErrorMessage = "{0} can not exceed {1} characters")]
        [MinLength(1, ErrorMessage = "{0} can not less than {1} characters")]
        public string Description { get; set; }

        [DisplayName("Activity")]
        [Required(ErrorMessage = "{0} can not be empty.")]
        public bool IsActive { get; set; }
        [DisplayName("Is Deleted")]
        [Required(ErrorMessage = "{0} can not be empty.")]
        public bool IsDeleted { get; set; }
    }
}
