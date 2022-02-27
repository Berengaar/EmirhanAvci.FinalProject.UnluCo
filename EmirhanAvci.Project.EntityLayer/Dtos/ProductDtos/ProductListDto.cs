using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.SharedLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Dtos.ProductDtos
{
    public class ProductListDto:DtoGetBase
    {
        [JsonPropertyName("products")]
        public IList<Product> Products { get; set; }

    }
}
