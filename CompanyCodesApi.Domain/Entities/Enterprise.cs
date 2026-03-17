using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Domain.Entities
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public long? Nit { get; set; }
        public long Gln { get; set;  }

        public ICollection<Code> Codes { get; set; } = new List<Code>();

    }
}
