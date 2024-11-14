namespace InsuranceTask.Interfaces
{
    public interface IProrateCalculator
    {
        double CalculateProrate(double fullPremium, DateTime additionDate, DateTime policyEndDate);
    }
}
