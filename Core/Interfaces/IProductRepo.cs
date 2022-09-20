using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepo
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
         Task<IReadOnlyList<ProductBrand>> GetProductsBrandAsync();
          Task<IReadOnlyList<ProductTyp>> GetProductsTypeAsync();
           //Task<IReadOnlyList<Product>> GetProductsAsync();

    }
}