using AutoMapper;
using CompanyCodesApi.Application.DTOs.Codes;
using CompanyCodesApi.Application.DTOs.Enterprises;
using CompanyCodesApi.Application.Interfaces;
using CompanyCodesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Application.Services
{
    public class CodeService
    {
        private readonly ICodeRepository _repo;
        private readonly IMapper _mapper;

        public CodeService(ICodeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CodeResponseDto>> GetByEnterprise(int enterpriseId)
        {
            var codes = await _repo.GetByEnterpriseId(enterpriseId);
            return _mapper.Map<List<CodeResponseDto>>(codes);
        }

        public async Task<CodeResponseDto?> GetById(int id)
        {
            var code = await _repo.GetById(id);
            return _mapper.Map<CodeResponseDto>(code);
        }
        public async Task<EnterpriseResponseDto?> GetEnterpriseByCodeId(int codeId)
        {
            var code = await _repo.GetById(codeId);

            if (code == null)
                return null;

            return _mapper.Map<EnterpriseResponseDto>(code.Owner);
        }

        public async Task Create(CreateCodeDto codeDto)
        {
            var code = _mapper.Map<Code>(codeDto);
            await _repo.Create(code);
        }

        public async Task<bool> Update(int id, UpdateCodeDto codeDto)
        {
            var code = await _repo.GetById(id);

            if (code == null) return false;

            _mapper.Map(codeDto, code);

            await _repo.Update(code);

            return true;
        }
    }
}
