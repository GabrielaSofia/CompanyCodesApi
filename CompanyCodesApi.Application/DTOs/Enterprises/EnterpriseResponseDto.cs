using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyCodesApi.Application.DTOs.Codes;

namespace CompanyCodesApi.Application.DTOs.Enterprises
{
    public class EnterpriseResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public long? Nit { get; set; }
        public long Gln { get; set; }

        public List<CodeResponseDto>? Codes {  get; set; }
    }
}
