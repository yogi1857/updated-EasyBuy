using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class ProductRepo : IProductRepo
    {
        public readonly StoreContext _context;
        public ProductRepo(StoreContext context){
       _context = context;
        }
      public async Task<Product> GetProductByIdAsync(int id){
            return await  _context.Products.FindAsync(id);


         }
       public async Task<IReadOnlyList<Product>> GetProductsAsync(){
return await _context.Products.ToListAsync();

         }

    }
}