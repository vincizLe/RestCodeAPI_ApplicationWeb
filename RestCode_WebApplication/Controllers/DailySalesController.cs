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
    public class DailySalesController : Controller
    {
        private readonly IDailySaleService _dailysaleService;
        private readonly IMapper _mapper;

        public DailySalesController(IDailySaleService dailysaleService, IMapper mapper)
        {
            _dailysaleService = dailysaleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DailySaleResource>> GetAllAsync()
        {
            var categories = await _dailysaleService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<DailySale>, IEnumerable<DailySaleResource>>(categories);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _dailysaleService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var dailysaleResource = _mapper.Map<DailySale, DailySaleResource>(result.Resource);
            return Ok(dailysaleResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDailySaleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var dailysale = _mapper.Map<SaveDailySaleResource, DailySale>(resource);
            var result = await _dailysaleService.SaveAsync(dailysale);

            if (!result.Success)
                return BadRequest(result.Message);

            var dailysaleResource = _mapper.Map<DailySale, DailySaleResource>(result.Resource);
            return Ok(dailysaleResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDailySaleResource resource)
        {
            var dailysale = _mapper.Map<SaveDailySaleResource, DailySale>(resource);
            var result = await _dailysaleService.UpdateAsync(id, dailysale);

            if (!result.Success)
                return BadRequest(result.Message);
            var dailysaleResource = _mapper.Map<DailySale, DailySaleResource>(result.Resource);
            return Ok(dailysaleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _dailysaleService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var dailysaleResource = _mapper.Map<DailySale, DailySaleResource>(result.Resource);
            return Ok(dailysaleResource);
        }
    }
}
