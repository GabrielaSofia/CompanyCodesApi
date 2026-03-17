using CompanyCodesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Application.Interfaces
{
    public interface ICodeRepository
    {
        Task<Code?> GetById(int id);
        Task<List<Code>> GetByEnterpriseId(int enterpriseId);
        Task Create(Code code);
        Task Update(Code code);
    }
}
