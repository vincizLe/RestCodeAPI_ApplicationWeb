using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        public double ProductPrice { get; set; }

        [Required]
        public double CategoryId { get; set; }
    }
}
