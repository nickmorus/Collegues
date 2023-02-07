using Colegues.Business.Exceptions;
using Collegues.Domain.Abstract;
using Collegues.Domain.Abstract.Calculators;
using Collegues.Domain.Collegues;

namespace Colegues.Business.Calculators
{
    public class SalesmanSalaryCalculator : EmployeeSalaryCalculatorBase, ISalesmanSalaryCalculator
    {
        double subordinateCoefficient;
        public SalesmanSalaryCalculator(double wageRate, double maxCoefficient, double yearCoefficient, double subordinateCoefficient)
            : base(wageRate, yearCoefficient, maxCoefficient)
        {
            this.subordinateCoefficient = subordinateCoefficient;
        }

        public double CalculateSalary(EmployeeBase employee, DateTime dateFrom, DateTime dateTo, IEmployeeSalaryCalculator salaryCalculator)
        {
            if (employee is not Salesman)
                throw new IncorrectEmployeeTypeException();

            if (employee.EmploymentFrom > dateTo)
                throw new IncorrectDateRangeException();

            Salesman salesman = (Salesman)employee;

            TimeSpan workTimeSpan = dateTo - employee.EmploymentFrom;
            int years = workTimeSpan.Days / daysInYear;

            double wage = wageRate;
            while (years-- > 0 && wage < maxWage)
            {
                wage += wageRate * yearCoefficient;
            }

            double subordinateWage = 0;
            foreach (EmployeeBase subordinate in salesman.Subordinates)
            {
                subordinateWage += salaryCalculator.CalculateSalary(subordinate, dateFrom, dateTo);
            }
            wage += subordinateWage * 0.003;

            return Math.Round(wage, 2);
        }
    }
}