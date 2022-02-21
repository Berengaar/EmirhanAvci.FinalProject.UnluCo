using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.DataAccessLayer.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBrandRepository Brands { get; }        //unitofwork.brands
        ICategoryRepository Categories { get; }
        IColorRepository Colors { get; }
        IOfferRepository Offers { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        /*
         _unitOfWork.Categories.AddAsync(category);
         _unitOfWork.Users.AddAsync(user);
         _unitOfWork.SaveAsync();
         */
        Task<int> SaveAsync();
    }
}
