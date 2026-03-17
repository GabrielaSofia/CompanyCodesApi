using CompanyCodesApi.Application.Services;
using CompanyCodesApi.Domain.Entities;
using CompanyCodesApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CompanyCodesApi.Application.DTOs.Codes;

namespace CompanyCodesApi.Api.Controllers
{
    [ApiController]
    [Route("api/codes")]
    public class CodesController : ControllerBase
    {
        private readonly CodeService _service;

        public CodesController(CodeService service)
        {
            _service = service;

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}/enterprise")]
        public async Task<IActionResult> GetEnterprise(int id)
        {
            var result = await _service.GetEnterpriseByCodeId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCodeDto code)
        {
            await _service.Create(code);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCodeDto code)
        {
            if(!await _service.Update(id, code))
                return NotFound();
            return NoContent();
        }
    }
}
