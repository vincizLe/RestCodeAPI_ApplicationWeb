using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communications;
using RestCode_WebApplication.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Services
{
    public class SaleDetailService : ISaleDetailService
    {
        private readonly ISaleDetailRepository _saleDetailRepository;

        public SaleDetailService(ISaleDetailRepository saleDetailRepository)
        {
            _saleDetailRepository = saleDetailRepository;
        }

        public async Task<IEnumerable<SaleDetail>> ListAsync()
        {
            return await _saleDetailRepository.ListAsync();
        }
        public async Task<IEnumerable<SaleDetail>> ListBySaleIdAsync(int SaleDetailId)
        {
            return await _saleDetailRepository.ListBySaleIdAsync(SaleDetailId);
        }
        public async Task<SaleDetailResponse> GetByIdAsync(int id)
        {
            var existingSaleDetail = await _saleDetailRepository.FindById(id);

            if (existingSaleDetail == null)
                return new SaleDetailResponse("SaleDetail not found");
            return new SaleDetailResponse(existingSaleDetail);
        }

        public async Task<SaleDetailResponse> SaveAsync(SaleDetail SaleDetail)
        {
            try
            {
                await _saleDetailRepository.AddAsync(SaleDetail);

                return new SaleDetailResponse(SaleDetail);
            }
            catch (Exception ex)
            {
                return new SaleDetailResponse($"An error ocurred while saving the SaleDetail: {ex.Message}");
            }
        }

        public async Task<SaleDetailResponse> UpdateAsync(int id, SaleDetail saleDetail)
        {
            var existingSaleDetail = await _saleDetailRepository.FindById(id);

            if (existingSaleDetail == null)
                return new SaleDetailResponse("SaleDetail not found");

            existingSaleDetail.Description = saleDetail.Description;
            existingSaleDetail.Quantity = saleDetail.Quantity;

            try
            {
                _saleDetailRepository.Update(existingSaleDetail);

                return new SaleDetailResponse(existingSaleDetail);
            }
            catch (Exception ex)
            {
                return new SaleDetailResponse($"An error ocurred while updating SaleDetail: {ex.Message}");
            }

        }

        public async Task<SaleDetailResponse> DeleteAsync(int id)
        {
            var existingSaleDetail = await _saleDetailRepository.FindById(id);

            if (existingSaleDetail == null)
                return new SaleDetailResponse("SaleDetail not found");

            try
            {
                _saleDetailRepository.Remove(existingSaleDetail);

                return new SaleDetailResponse(existingSaleDetail);
            }
            catch (Exception ex)
            {
                return new SaleDetailResponse($"An error ocurred while deleting SaleDetail: {ex.Message}");
            }
        }
    }
}
