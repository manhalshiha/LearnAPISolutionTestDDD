using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchDomain
{
    public class CompanyService
    {
        public int ServiceId { get; set; }
        public required string ServiceName { get; set; }
        public required string ServiceDescription { get; set; }
        public List<CompanyBranch>? MyProperty { get; set; }
    }
}
