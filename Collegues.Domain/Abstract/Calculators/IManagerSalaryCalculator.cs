using Collegues.Domain.Collegues;

namespace Collegues.Domain.Abstract.Calculators
{
    public interface IManagerSalaryCalculator
    {
        public double CalculateSalary(EmployeeBase employee, DateTime dateFrom, DateTime dateTo, IEmployeeSalaryCalculator salaryCalculator);
    }
}
