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
    public class EfBrandRepository:EfEntityRepositoryBase<Brand>,IBrandRepository
    {
        public EfBrandRepository(DbContext context):base(context)
        {

        }
    }
}
