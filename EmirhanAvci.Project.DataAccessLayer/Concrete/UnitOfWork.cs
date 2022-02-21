using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.DataAccessLayer.Concrete.EntityFramework.Contexts;
using EmirhanAvci.Project.DataAccessLayer.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.DataAccessLayer.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmirhanAvciProjectContext _context;
        private EfCategoryRepository _categoryRepository;
        private EfBrandRepository _brandRepository;
        private EfColorRepository _colorRepository;
        private EfOfferRepository _offerRepository;
        private EfOrderRepository _orderRepository;
        private EfProductRepository _productRepository;

        public UnitOfWork(EmirhanAvciProjectContext context)
        {
            _context = context;
        }

        public IBrandRepository Brands => _brandRepository ?? new EfBrandRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);

        public IColorRepository Colors => _colorRepository ?? new EfColorRepository(_context);

        public IOfferRepository Offers => _offerRepository ?? new EfOfferRepository(_context);

        public IOrderRepository Orders => _orderRepository ?? new EfOrderRepository(_context);

        public IProductRepository Products => _productRepository ?? new EfProductRepository(_context);


      

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
