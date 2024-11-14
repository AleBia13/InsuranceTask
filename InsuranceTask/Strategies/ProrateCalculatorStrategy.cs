using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceTask.Strategies
{
    public delegate decimal ProrateCalculatorStrategy(decimal fullPremium, DateTime additionDate, DateTime policyEndDate);

    public static class ProrateCalculatorStrategies
    {
        public static decimal ProrateByDays(decimal fullPremium, DateTime additionDate, DateTime policyEndDate)
        {
            var days = (policyEndDate - additionDate).Days + 1;
            return Math.Round(fullPremium / 366 * days, 2);
        }

        public static decimal ProrateByMonths(decimal fullPremium, DateTime additionDate, DateTime policyEndDate)
        {
            var months = ((policyEndDate.Year - additionDate.Year) * 12) + policyEndDate.Month - additionDate.Month + 1;
            return Math.Round(fullPremium / 12 * months, 2);
        }
    }
}
