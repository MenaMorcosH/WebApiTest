using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int  Price { get; set; }
    }
}
