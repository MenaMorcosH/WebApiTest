using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Commands.infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ProductRepository(ApplicationContext applicationContext )
        {
            _applicationContext = applicationContext;
        }
        public void Add(Product Entity)
        {
           _applicationContext.Set<Product>().Add(Entity);

            _applicationContext.SaveChanges();
        }

       

        public void Delete(int id)
        {
            Product p = _applicationContext.Set<Product>().Where(p => p.Id == id).FirstOrDefault();
            _applicationContext.Set<Product>().Remove(p);
            _applicationContext.SaveChanges();
        }

       

        public IEnumerable<Product> Select()
        {
          return _applicationContext.Set<Product>().ToList();
        }

        public Product Select(int Id)
        {
            return _applicationContext.Set<Product>().Where(p => p.Id == Id).FirstOrDefault();
        }

        public void Update(Product Entity)
        {
            _applicationContext.Entry<Product>(Entity).State = EntityState.Modified;
            _applicationContext.SaveChanges();
        }
    }
}
