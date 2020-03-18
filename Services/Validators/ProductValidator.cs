using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Services.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Is necessary to inform the product Name.")
                .MaximumLength(50).WithMessage("Product Name must be no longer than 50 characters.")
                .NotNull().WithMessage("Is necessary to inform the ProductName Name.");
                

               RuleFor(p => p.Price)
                .Must(ValidateProductPrice).WithMessage("Product Price must be greater than 2 Dollar");



        }


        private bool ValidateProductPrice(int price)
        {

            if (price < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
