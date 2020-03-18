using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Commands.infrastructure;
using WebApiTest.Models;

namespace WebApiTest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _IProductRepository;
        public ProductService(IProductRepository iProductRepository)
        {
            _IProductRepository = iProductRepository;
        }
        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            _IProductRepository.Delete(id);
        }

        public Product Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return _IProductRepository.Select(id);
        }

        public List<Product> GetAll()
        {
            return _IProductRepository.Select().ToList();
        }

        public Product post<V>(Product obj) where V : AbstractValidator<Product>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _IProductRepository.Add(obj);
            return obj;
        }

        public Product Put<V>(Product obj) where V : AbstractValidator<Product>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _IProductRepository.Update(obj);
            return obj;
        }

        private void Validate(Product obj, AbstractValidator<Product> validator)
        {
            if (obj == null)
                  throw new Exception("Record Not Found");

            validator.ValidateAndThrow(obj);
        }
    }
}
