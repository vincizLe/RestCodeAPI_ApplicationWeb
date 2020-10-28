using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class ConsultantResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Validation { get; set; }
        public string LinkedinLink { get; set; }
    }
}
