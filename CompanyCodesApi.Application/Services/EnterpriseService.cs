using AutoMapper;
using CompanyCodesApi.Application.Interfaces;
using CompanyCodesApi.Application.DTOs.Enterprises;
using CompanyCodesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Application.Services
{
    public class EnterpriseService
    {
        private readonly IEnterpriseRepository _repo;
        private readonly IMapper _mapper;

        public EnterpriseService(IEnterpriseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<EnterpriseResponseDto>> GetAll()
        {
            var enterprises = await _repo.GetAll();
            return _mapper.Map<List<EnterpriseResponseDto>>(enterprises);
        }

        public async Task<EnterpriseResponseDto?> GetById(int id)
        {
            var enterprises = await _repo.GetById(id);
            return _mapper.Map<EnterpriseResponseDto>(enterprises);
        }


        public async Task<EnterpriseResponseDto?> GetByNit(long nit)
        {
            var enterprises = await _repo.GetByNit(nit);
            return _mapper.Map<EnterpriseResponseDto>(enterprises);
        }

        public async Task Create(CreateEnterpriseDto enterpriseDto)
        {
            var enterprise = _mapper.Map<Enterprise>(enterpriseDto);
            await _repo.Create(enterprise);
        }

        public async Task<bool> Update(int id, UpdateEnterpriseDto enterpriseDto)
        {
            var enterprise = await _repo.GetById(id);

            if (enterprise == null) return false;

            _mapper.Map(enterpriseDto, enterprise);
            
            await _repo.Update(enterprise);
            return true;
        }
    }
}
