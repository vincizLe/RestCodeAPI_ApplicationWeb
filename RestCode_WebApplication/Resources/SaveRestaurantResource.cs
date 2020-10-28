using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class SaveRestaurantResource
    {
        [Required]
        [MaxLength(100)]
        public string RestaurantName { get; set; }

        [Required]
        [MaxLength(100)]
        public string RestaurantAddress { get; set; }

        [Required]
        public int RestaurantCellPhoneNumber { get; set; }
    }
}
