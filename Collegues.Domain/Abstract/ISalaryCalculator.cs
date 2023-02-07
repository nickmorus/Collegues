using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegues.Domain.Abstract
{
    public interface IEmployeeSalaryCalculator
    {
        public double CalculateSalary(EmployeeBase employee, DateTime dateFrom, DateTime finalDate);
    }
}
