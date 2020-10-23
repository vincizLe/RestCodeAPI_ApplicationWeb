using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } 
        public int CellphoneNumber { get; set; }
        public long Ruc { get; set; }

        public IList<Category> Categories { get; set; } = new List<Category>();

        public IList<DailySale> DailySales { get; set; } = new List<DailySale>();

    }
}
