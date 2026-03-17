using CompanyCodesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Application.Interfaces
{
    public interface IEnterpriseRepository
    {
        Task<List<Enterprise>> GetAll();
        Task<Enterprise?> GetById(int id);
        Task<Enterprise?> GetByNit(long nit);
        Task Create(Enterprise enterprise);
        Task Update(Enterprise enterprise);
    }
}
