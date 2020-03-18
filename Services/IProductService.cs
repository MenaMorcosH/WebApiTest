using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Services
{
    public interface IProductService
    {

        Product post<V> (Product obj) where V : AbstractValidator<Product>;

        Product Put<V>(Product obj) where V : AbstractValidator<Product>;
        List<Product> GetAll();
        Product Get(int id);

        void Delete(int id);

    }
}
