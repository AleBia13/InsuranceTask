using InsuranceTask.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceTask.Interfaces
{
    public interface IPricingModel
    {
        double CalculateFullPremium(int? age, Gender? gender);
    }
}
