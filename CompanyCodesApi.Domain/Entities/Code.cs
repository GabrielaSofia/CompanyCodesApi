using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Domain.Entities
{
    public class Code
    {
        public int Id { get; set; }
        public Enterprise Owner { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 
        public int EnterpriseId {  get; set; }
    }
}
