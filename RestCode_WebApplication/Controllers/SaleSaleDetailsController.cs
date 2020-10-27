using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Controllers
{
    [Route("/api/sales/{saleId}/saleDetails")]
    public class SaleSaleDetailsController
    {
        private readonly ISaleDetailService _saleDetailService;
        private readonly IMapper _mapper;

        public SaleSaleDetailsController(ISaleDetailService saleDetailService, IMapper mapper)
        {
            _saleDetailService = saleDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SaleDetailResource>> GetAllBySaleIdAsync(int saleId)
        {
            var saleDetails = await _saleDetailService.ListBySaleIdAsync(saleId);
            var resources = _mapper
                .Map<IEnumerable<SaleDetail>, IEnumerable<SaleDetailResource>>(saleDetails);
            return resources;
        }
    }
}
