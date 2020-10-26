using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Extensions;
using RestCode_WebApplication.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Controllers
{
    [Route("/api/[controller]")]
    public class SaleController : Controller
    {
        private readonly ISaleDetailService _saleDetailService;
        private readonly IMapper _mapper;

        public SaleController(ISaleDetailService saleDetailService, IMapper mapper)
        {
            _saleDetailService = saleDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SaleDetailResource>> GetAllAsync()
        {
            var sale = await _saleDetailService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<SaleDetail>, IEnumerable<SaleDetailResource>>(sale);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _saleDetailService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var saleDetailResource = _mapper.Map<SaleDetail, SaleDetailResource>(result.Resource);
            return Ok(saleDetailResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSaleDetailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var saleDetail = _mapper.Map<SaveSaleDetailResource, SaleDetail>(resource);
            var result = await _saleDetailService.SaveAsync(saleDetail);

            if (!result.Success)
                return BadRequest(result.Message);

            var saleDetailResource = _mapper.Map<SaleDetail, SaleDetailResource>(result.Resource);
            return Ok(saleDetailResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSaleDetailResource resource)
        {
            var saleDetail = _mapper.Map<SaveSaleDetailResource, SaleDetail>(resource);
            var result = await _saleDetailService.UpdateAsync(id, saleDetail);

            if (!result.Success)
                return BadRequest(result.Message);
            var saleDetailResource = _mapper.Map<SaleDetail, SaleDetailResource>(result.Resource);
            return Ok(saleDetailResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _saleDetailService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var saleDetailResource = _mapper.Map<SaleDetail, SaleDetailResource>(result.Resource);
            return Ok(saleDetailResource);
        }
    }
}
