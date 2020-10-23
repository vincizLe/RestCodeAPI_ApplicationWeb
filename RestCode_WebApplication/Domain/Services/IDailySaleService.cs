using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services
{
    public interface IDailySaleService
    {
        Task<IEnumerable<DailySale>> ListAsync();
        Task<DailySaleResponse> GetByIdAsync(int id);
        Task<DailySaleResponse> SaveAsync(DailySale dailysale);
        Task<DailySaleResponse> UpdateAsync(int id, DailySale dailysale);
        Task<DailySaleResponse> DeleteAsync(int id);
    }
}
