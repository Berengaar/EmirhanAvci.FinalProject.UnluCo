using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.SharedLayer.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.DataAccessLayer.Concrete.EntityFramework.Repositories
{
    public class EfOrderRepository:EfEntityRepositoryBase<Order>,IOrderRepository
    {
        public EfOrderRepository(DbContext context) : base(context)
        {

        }
    }
}
