using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchDomain
{
    public class CompanyBranch
    {
        public int BranchId { get;private set; }
        [Required]
        public string? BranchName { get;private set; }
        public BranchClassification BranchClass { get;private set; } = BranchClassification.FollowedMainBranch;
        
        public Address BranchAddress { get;private set; } = new Address();

        public List<Department> departments { get;private set; } = new();
        public List<Project> Projects { get;private set; } = new();
        public List<Employee> Employees { get;private set; } = new();




        public List<CompanyService> BranchServices { get;private set; } = new();

        public double Expenses { get;private set; }=GetExpenses();

        public double Profits { get;private set; }= GetProfits();
        public double NetProfit { get;private set; }= GetNetProfit();

        public double PayrollBlock { get;private set; }= GetPayrollBlock();

        private static double GetPayrollBlock()
        {
            throw new NotImplementedException();
        }

        private static double GetNetProfit()
        {
            throw new NotImplementedException();
        }

        private static double GetProfits()
        {
            throw new NotImplementedException();
        }

        private static double GetExpenses()
        {
            throw new NotImplementedException();
        }





    }
}
