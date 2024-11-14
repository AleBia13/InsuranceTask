using InsuranceTask.Enum;
using InsuranceTask.Strategies;

namespace InsuranceTask.Factories.StrategyFactories
{
    public static class ProrateCalculatorFactory
    {
        public static ProrateCalculatorStrategy GetProrateCalculation(ProrateCalculationType type)
        {
            return type switch
            {
                ProrateCalculationType.ByDays => ProrateCalculatorStrategies.ProrateByDays,
                ProrateCalculationType.ByMonths => ProrateCalculatorStrategies.ProrateByMonths,
                _ => throw new ArgumentException("Invalid prorate calculation type")
            };
        }
    }
}
