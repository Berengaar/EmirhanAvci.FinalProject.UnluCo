using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.SharedLayer.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.DataAccessLayer.Abstract
{
    public interface IOrderRepository:IEntityRepository<Order>
    {
    }
}
