using Microsoft.EntityFrameworkCore;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Persistence.Contexts;
using RestCode_WebApplication.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Persistence.Repositories
{
    public class DailySaleRepository : BaseRepository, IDailySaleRepository
    {
        public DailySaleRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<DailySale>> ListAsync()
        {

            return await _context.DailySales.ToListAsync();
        }

        public async Task AddAsync(DailySale dailysale)
        {
            await _context.DailySales.AddAsync(dailysale);
        }

        public async Task<DailySale> FindById(int id)
        {
            return await _context.DailySales.FindAsync(id);
        }

        public void Update(DailySale dailysale)
        {
            _context.DailySales.Update(dailysale);
        }

        public void Remove(DailySale dailysale)
        {
            _context.DailySales.Remove(dailysale);
        }
    }
}
