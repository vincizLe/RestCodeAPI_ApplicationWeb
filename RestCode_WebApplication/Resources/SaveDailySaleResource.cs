using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace RestCode_WebApplication.Resources
{
    public class SaveDailySaleResource
    {
        [Required]
        [MaxLength(100)]
        public int QuantityDailySales { get; set; }

        [Required]
        [MaxLength(100)]
        public float Incomes { get; set; }

        [Required]
        [MaxLength(100)]
        public float Expenses { get; set; }

        [Required]
        [MaxLength(50)]
        public string TypeMenuDay { get; set; }


    }
}
