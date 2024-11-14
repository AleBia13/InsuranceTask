using InsuranceTask.Enum;
using InsuranceTask.Strategies;

namespace InsuranceTask.Factories.StrategyFactories
{
    public static class PricingModelFactory
    {
        public static PricingModelStrategy GetPricingModel(PricingModelType type)
        {
            return type switch
            {
                PricingModelType.FlatRate => PricingModelStrategies.FlatRatePricing,
                PricingModelType.AgeRate => PricingModelStrategies.AgeRatePricing,
                PricingModelType.GenderAgeRate => PricingModelStrategies.GenderAgeRatePricing,
                _ => throw new ArgumentException("Invalid pricing model type")
            };
        }
    }
}
