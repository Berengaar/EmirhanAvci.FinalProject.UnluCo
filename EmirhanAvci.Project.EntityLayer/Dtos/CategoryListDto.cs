using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.SharedLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Dtos
{
    public class CategoryListDto:DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
