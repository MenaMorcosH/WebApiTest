using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Commands.infrastructure
{
    public interface IProductRepository
    {
        IEnumerable<Product> Select();

         Product Select(int Id);
        void Add (Product Entity);
       

        void Update(Product Entity);

        void Delete(int id);

      

    }
}
