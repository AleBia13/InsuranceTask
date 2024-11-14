using InsuranceTask.Enum;

namespace InsuranceTask.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Company { get; set; }
        public DateTime AdditionDate { get; set; }
    }
}
