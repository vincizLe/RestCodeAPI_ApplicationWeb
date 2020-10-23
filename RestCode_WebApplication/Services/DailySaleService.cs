using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Services
{
    public class DailySaleService : IDailySaleService
    {
        private readonly IDailySaleRepository _dailysaleRepository;

        public DailySaleService(IDailySaleRepository dailysaleRepository)
        {
            _dailysaleRepository = dailysaleRepository;
        }

        public async Task<IEnumerable<DailySale>> ListAsync()
        {
            return await _dailysaleRepository.ListAsync();
        }

        public async Task<DailySaleResponse> GetByIdAsync(int id)
        {
            var existingDailySale = await _dailysaleRepository.FindById(id);

            if (existingDailySale == null)
                return new DailySaleResponse("DailySale not found");
            return new DailySaleResponse(existingDailySale);
        }

        public async Task<DailySaleResponse> SaveAsync(DailySale DailySale)
        {
            try
            {
                await _dailysaleRepository.AddAsync(DailySale);

                return new DailySaleResponse(DailySale);
            }
            catch (Exception ex)
            {
                return new DailySaleResponse($"An error ocurred while saving the DailySale: {ex.Message}");
            }
        }

        public async Task<DailySaleResponse> UpdateAsync(int id, DailySale dailysale)
        {
            var existingDailySale = await _dailysaleRepository.FindById(id);

            if (existingDailySale == null)
                return new DailySaleResponse("DailySale not found");

            existingDailySale.QuantityDailySales = dailysale.QuantityDailySales;
            existingDailySale.Incomes = dailysale.Incomes;
            existingDailySale.Expenses = dailysale.Expenses;
            existingDailySale.TypeMenuDay = dailysale.TypeMenuDay;

            try
            {
                _dailysaleRepository.Update(existingDailySale);

                return new DailySaleResponse(existingDailySale);
            }
            catch (Exception ex)
            {
                return new DailySaleResponse($"An error ocurred while updating DailySale: {ex.Message}");
            }

        }

        public async Task<DailySaleResponse> DeleteAsync(int id)
        {
            var existingDailySale = await _dailysaleRepository.FindById(id);

            if (existingDailySale == null)
                return new DailySaleResponse("DailySale not found");

            try
            {
                _dailysaleRepository.Remove(existingDailySale);

                return new DailySaleResponse(existingDailySale);
            }
            catch (Exception ex)
            {
                return new DailySaleResponse($"An error ocurred while deleting DailySale: {ex.Message}");
            }
        }
    }
}
