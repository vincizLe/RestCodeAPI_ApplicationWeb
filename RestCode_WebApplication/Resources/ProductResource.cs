using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
