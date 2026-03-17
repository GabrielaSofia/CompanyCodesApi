using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Application.DTOs.Codes
{
    public class CreateCodeDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int EnterpriseID { get; set; }
    }
}
