using InsuranceTask.DTO;
using InsuranceTask.Interfaces;
using InsuranceTask.Strategies;

namespace InsuranceTask.Services
{
    public class PremiumPolicyCalculator : IPremiumPolicyCalculator
    {
        private readonly PricingModelStrategy _pricingModel;
        private readonly ProrateCalculatorStrategy _prorateCalculation;
        public PremiumPolicyCalculator(PricingModelStrategy pricingModel, ProrateCalculatorStrategy prorateCalculation)
        {
            _pricingModel = pricingModel;
            _prorateCalculation = prorateCalculation;
        }

        public Tuple<Guid, decimal, decimal> CalculatePremium(EmployeeDTO employee, DateTime policyEndTime)
        {
            try
            {
                var fullPremium = _pricingModel(employee.Age, employee.Gender);
                var proratePrice = _prorateCalculation(fullPremium, employee.AdditionDate, policyEndTime);
                return Tuple.Create(employee.Id, fullPremium, proratePrice);
            }
            catch(Exception ex)
            {

               throw new Exception("Error calculating premium", ex);
            }
        }
    }
}
