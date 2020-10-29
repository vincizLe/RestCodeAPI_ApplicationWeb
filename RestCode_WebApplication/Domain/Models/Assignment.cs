using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public bool State { get; set; }

        //Relationships

        //One to One with Restaurant
        //public int RestaurantId { get; set; }
        //public Restaurant Restaurant { get; set; }

        //Many to One with Consultant
        //public int ConsultantId { get; set; }
        //public Consultant Consultant { get; set; }
    }
}
