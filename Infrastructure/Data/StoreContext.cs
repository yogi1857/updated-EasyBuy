using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;



namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(){

        }
        public StoreContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products {get;set;}
        public DbSet<ProductBrand> ProductBrands{get;set;}
        public DbSet<ProductTyp> ProductTypes {get;set;}
        protected override void  OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
