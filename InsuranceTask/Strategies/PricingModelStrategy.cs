using InsuranceTask.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceTask.Strategies
{
    public delegate decimal PricingModelStrategy(int age, Gender gender);

    public static class PricingModelStrategies
    {
        public static decimal FlatRatePricing(int age, Gender gender)
        {
            return Math.Round(1000m, 2);
        }

        public static decimal AgeRatePricing(int age, Gender gender)
        {
            var multiplier = (age / 10 + 1) * 100m;
            return Math.Round(multiplier, 2);
        }

        public static decimal GenderAgeRatePricing(int age, Gender gender)
        {
            var basePremium = (age / 10 + 1) * 100m;
            if (gender == Gender.Female && age > 18)
            {
                basePremium *= 1.5m;
            }
            return Math.Round(basePremium, 2);
        }
    }
}
