using Colegues.Business.Exceptions;
using Collegues.Domain.Abstract;
using Collegues.Domain.Abstract.Calculators;
using Collegues.Domain.Collegues;

namespace Colegues.Business.Calculators
{
    public class ManagerSalaryCalculator : EmployeeSalaryCalculatorBase, IManagerSalaryCalculator
    {

        private double subordinateCoefficient;

        public ManagerSalaryCalculator(double wageRate, double maxCoefficient, double yearCoefficient, double subordinateCoefficient)
            : base(wageRate, maxCoefficient, yearCoefficient)
        {
            this.subordinateCoefficient = subordinateCoefficient;
        }

        public double CalculateSalary(EmployeeBase employee, DateTime dateFrom, DateTime dateTo, IEmployeeSalaryCalculator salaryCalculator)
        {
            if (employee is not Manager)
                throw new IncorrectEmployeeTypeException();

            if (dateFrom > dateTo)
                throw new IncorrectDateRangeException();

            Manager manager = (Manager)employee;
            TimeSpan workTimeSpan = dateTo - employee.EmploymentFrom;
            int years = workTimeSpan.Days / daysInYear;

            double wage = wageRate;
            while (years-- > 0 && wage < maxWage)
            {
                wage += wageRate * yearCoefficient;
            }

            double subordinateWage = 0;
            foreach (EmployeeBase subordinate in manager.Subordinates)
            {
                subordinateWage += salaryCalculator.CalculateSalary(subordinate, dateFrom, dateTo);
            }
            wage += subordinateWage * subordinateCoefficient;

            return Math.Round(wage, 2);
        }
    }
}