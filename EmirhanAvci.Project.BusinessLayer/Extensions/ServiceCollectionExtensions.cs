using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.BusinessLayer.Concrete;
using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.DataAccessLayer.Concrete;
using EmirhanAvci.Project.DataAccessLayer.Concrete.EntityFramework.Contexts;
using EmirhanAvci.Project.DataAccessLayer.Concrete.EntityFramework.Repositories;
using EmirhanAvci.Project.EntityLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            //Context
            //UnitOfWork
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            //Services
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IProductService, ProductManager>();
            serviceCollection.AddScoped<IBrandService, BrandManager>();
            serviceCollection.AddScoped<IColorService, ColorManager>();
            serviceCollection.AddScoped<IOfferService, OfferManager>();
            serviceCollection.AddScoped<IOrderService, OrderManager>();

            return serviceCollection;
        }
    }
}
