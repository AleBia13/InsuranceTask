using InsuranceTask.DTO;
using InsuranceTask.Factories.StrategyFactories;
using InsuranceTask.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var premiumPolicy = new PremiumPolicyDTO()
        {
            Company = "Teambase",
            Id = new Guid(),
            Employees = new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    Id = new Guid(),
                    Age = 25,
                }
            },
            PolicyEndDate = DateTime.Now.AddDays(5),
            PricingModelType = InsuranceTask.Enum.PricingModelType.AgeRate,
            ProrateCalculationType = InsuranceTask.Enum.ProrateCalculationType.ByDays
        };

        var newEmployee = new EmployeeDTO()
        {
            Id = new Guid(),
            Age = 25,
            Gender = InsuranceTask.Enum.Gender.Male,
            AdditionDate = DateTime.Now,
            Company = "Teambase"
        };

        var pricingModel = PricingModelFactory.GetPricingModel(premiumPolicy.PricingModelType);
        var prorateCalculation = ProrateCalculatorFactory.GetProrateCalculation(premiumPolicy.ProrateCalculationType);
        
        var calculator = new PremiumPolicyCalculator(pricingModel, prorateCalculation);

        if (premiumPolicy.PolicyEndDate <= DateTime.Now)
        {
            Console.WriteLine("The policy has expired");
            return;
        }

        if (newEmployee.Company != premiumPolicy.Company)
        {
            Console.WriteLine("Employee does not belong to the company");
            return;
        }

        var result = calculator.CalculatePremium(newEmployee, premiumPolicy.PolicyEndDate);
        Console.WriteLine($"Employee {result.Item1} has full premium of {result.Item2} USD and prorate of {result.Item3} USD");
    }
}