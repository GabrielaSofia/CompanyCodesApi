using CompanyCodesApi.Domain.Entities;
using CompanyCodesApi.Infrastructure.Context;
using CompanyCodesApi.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Infrastructure.Repositories
{
    public class CodeRepository : ICodeRepository
    {
        private readonly AppDbContext _context;

        public CodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Code?> GetById(int id)
        {
            return await _context.Codes
                .Include(c => c.Owner)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Code>> GetByEnterpriseId(int enterpriseId)
        {
            return await _context.Codes
                .Where(c => c.EnterpriseId == enterpriseId)
                .ToListAsync();
        }

        public async Task Create (Code code)
        {
            _context.Codes.Add(code);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Code code)
        {
            _context.Codes.Update(code);
            await _context.SaveChangesAsync();
        }
    }
}
