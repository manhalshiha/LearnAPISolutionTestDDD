
using SharedKernel;

namespace BranchDomain
{
    public class Department : Entity<int>
    {
        private readonly int id;

        public Department(int id) : base(id)
        {
            this.id = id;
        }
    }
}