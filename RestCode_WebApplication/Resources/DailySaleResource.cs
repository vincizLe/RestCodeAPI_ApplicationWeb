using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class DailySaleResource
    {
        public int Id { get; set; }
        public float Incomes { get; set; }
        public float Expenses { get; set; }
        public string TypeMenuDay { get; set; }
    }
}
