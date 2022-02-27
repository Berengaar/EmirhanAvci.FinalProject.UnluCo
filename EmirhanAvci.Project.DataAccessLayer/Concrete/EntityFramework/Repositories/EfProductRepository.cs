using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.DataAccessLayer.Concrete.EntityFramework.Contexts;
using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos.ProductDtos;
using EmirhanAvci.Project.SharedLayer.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.DataAccessLayer.Concrete.EntityFramework.Repositories
{
    public class EfProductRepository : EfEntityRepositoryBase<Product>, IProductRepository
    {
        private readonly DbContext _context;
        public EfProductRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UploadAsync(ProductUpdateDto product)
        {
            await Task.Run(() => _context.Set<ProductUpdateDto>().Update(product));
            await _context.SaveChangesAsync();
        }
    }
}
