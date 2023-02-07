using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegues.Business.Calculators
{
    public abstract class EmployeeSalaryCalculatorBase
    {
        protected const int daysInYear = 365;

        protected readonly double wageRate;
        protected readonly double yearCoefficient;
        protected readonly double maxWage;

        public EmployeeSalaryCalculatorBase(double wageRate, double maxCoefficient, double yearCoefficient)
        {
            this.wageRate = wageRate;
            this.yearCoefficient = yearCoefficient;
            this.maxWage = wageRate * maxCoefficient;
        }
    }
}
