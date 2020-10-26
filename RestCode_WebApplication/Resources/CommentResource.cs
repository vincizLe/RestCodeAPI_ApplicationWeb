using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class CommentResource
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Description { get; set; }
    }
}
