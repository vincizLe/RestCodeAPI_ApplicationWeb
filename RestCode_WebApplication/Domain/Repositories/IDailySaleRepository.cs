using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface IDailySaleRepository
    {
        Task<IEnumerable<DailySale>> ListAsync();
        Task AddAsync(DailySale dailysale);
        Task<DailySale> FindById(int id);
        void Update(DailySale dailysale);
        void Remove(DailySale dailysale);
    }
}
