using InsuranceTask.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceTask.Interfaces
{
    public interface IPremiumPolicyCalculator
    {
        Tuple<Guid, decimal, decimal> CalculatePremium(EmployeeDTO employee, DateTime policyEndDate);
    }
}
