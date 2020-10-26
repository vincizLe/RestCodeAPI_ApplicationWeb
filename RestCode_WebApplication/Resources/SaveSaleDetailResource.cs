using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace RestCode_WebApplication.Resources
{
    public class SaveSaleDetailResource
    {
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public int Quantity { get; set; }

    }
}
