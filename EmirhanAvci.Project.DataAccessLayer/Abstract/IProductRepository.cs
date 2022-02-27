using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos.ProductDtos;
using EmirhanAvci.Project.SharedLayer.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.DataAccessLayer.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>
    {
    }
}
