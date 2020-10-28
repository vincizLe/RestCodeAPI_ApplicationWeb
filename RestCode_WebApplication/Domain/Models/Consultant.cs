using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Consultant : Profile
    {
       // public int Id { get; set; }
        public bool Validation { get; set; }
        public string LinkedinLink { get; set; }

        //Relationship
        //public int ProfileId { get; set; } //foreign key
        //public Profile Profile { get; set; }
    }
}
