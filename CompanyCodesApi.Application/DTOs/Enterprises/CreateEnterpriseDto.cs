using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Application.DTOs.Enterprises
{
    public class CreateEnterpriseDto
    {
        public string Name { get; set; } = null!;
        public long? Nit { get; set; }
        public long Gln { get; set; }
    }
}
