using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string CategoryName { get; set; }

        [Required]
        public int RestaurantId { get; set; }

    }
}
