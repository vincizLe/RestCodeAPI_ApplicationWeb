using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public int RestaurantCellPhoneNumber { get; set; }

        public IList<Category>Categories{ get; set; } = new List<Category>();

    }
}
