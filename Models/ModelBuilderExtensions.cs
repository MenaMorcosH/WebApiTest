using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "product 1 ",
                    Price = 15
                },
                 new Product
                 {
                     Id = 2,
                     Name = "product 2 ",
                     Price = 20
                 }
                ); 


        }
    }
}
