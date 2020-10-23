using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services.Communications
{
    public class DailySaleResponse : BaseResponse<DailySale>
    {
        public DailySaleResponse(string message) : base(message) { }
        public DailySaleResponse(DailySale dailysale) : base(dailysale) { }

    }
}
