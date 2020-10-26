﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
