using BranchApplication.PluginRepositories;
using BranchDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchInfrastructure.BranchImplementation
{
    public class BranchRepository : IBranchRepository
    {
        public Task AddBranch(CompanyBranch newBranch)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBranch(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyBranch>> GetAllBranches()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyBranch> GetBranchById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBranch(CompanyBranch newBranch)
        {
            throw new NotImplementedException();
        }
    }
}
