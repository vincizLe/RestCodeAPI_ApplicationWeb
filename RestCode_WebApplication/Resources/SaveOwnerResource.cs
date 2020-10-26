using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace RestCode_WebApplication.Resources
{
    public class SaveOwnerResource
    {
        [Required]
        [MaxLength(100)]
        public long RUC { get; set; }
                
    }
}
