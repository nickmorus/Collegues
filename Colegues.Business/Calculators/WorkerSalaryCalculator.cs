using Colegues.Business.Exceptions;
using Collegues.Domain.Abstract;
using Collegues.Domain.Abstract.Calculators;
using Collegues.Domain.Collegues;

namespace Colegues.Business.Calculators
{
    public class WorkerSalaryCalculator : EmployeeSalaryCalculatorBase, IWorkerSalaryCalculator
    {
        public WorkerSalaryCalculator(double wageRate, double maxCoefficient, double yearCoefficient)
            : base(wageRate, maxCoefficient, yearCoefficient) { }

        public double CalculateSalary(EmployeeBase employee, DateTime dateFrom, DateTime dateTo)
        {
            if (employee is not Worker)
                throw new IncorrectEmployeeTypeException();

            if (dateFrom > dateTo)
                throw new IncorrectDateRangeException();

            TimeSpan workTimeSpan = dateTo - dateFrom;
            int years = workTimeSpan.Days / daysInYear;

            double resultWage = wageRate;
            while (years-- > 0 && resultWage < maxWage)
            {
                resultWage += wageRate * yearCoefficient;
            }

            return Math.Round(resultWage, 2);
        }
    }
}