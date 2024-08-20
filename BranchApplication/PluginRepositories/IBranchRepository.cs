using BranchDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchApplication.PluginRepositories
{
    public interface IBranchRepository
    {
        public Task<List<CompanyBranch>> GetAllBranches();
        public Task<CompanyBranch> GetBranchById(int id);
        public Task AddBranch(CompanyBranch newBranch);
        public Task DeleteBranch(int id);
        public Task UpdateBranch(CompanyBranch newBranch);

    }
}
