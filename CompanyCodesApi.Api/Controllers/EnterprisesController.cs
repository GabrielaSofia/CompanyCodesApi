using CompanyCodesApi.Application.DTOs.Enterprises;
using CompanyCodesApi.Application.Services;
using CompanyCodesApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CompanyCodesApi.Api.Controllers
{
    [ApiController]
    [Route("api/enterprises")]
    public class EnterprisesController : ControllerBase
    {
        private readonly EnterpriseService _service;
        private readonly CodeService _codeservice;

        public EnterprisesController(EnterpriseService service, CodeService codeService)
        {
            _service = service;
            _codeservice = codeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("nit/{nit}")]
        public async Task<IActionResult> GetByNit(long nit)
        {
            var result = await _service.GetByNit(nit);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}/codes")]
        public async Task<IActionResult> GetCodes(int id)
        {
            var result = await _codeservice.GetByEnterprise(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnterpriseDto enterprise)
        {
            await _service.Create(enterprise);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEnterpriseDto enterprise)
        {
            if(!await _service.Update(id, enterprise))
                return NotFound();
            return NoContent();
        }
    }
}
