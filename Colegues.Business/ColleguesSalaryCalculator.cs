using Collegues.Domain.Abstract;
using Collegues.Domain.Abstract.Calculators;
using Collegues.Domain.Collegues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegues.Business
{
    public class ColleguesSalaryCalculator : IEmployeeSalaryCalculator
    {
        private IWorkerSalaryCalculator workerSalaryCalculator;
        private IManagerSalaryCalculator managerSalaryCalculator;
        private ISalesmanSalaryCalculator salesmanSalaryCalculator;

        public ColleguesSalaryCalculator(IWorkerSalaryCalculator workerSalaryCalculator, IManagerSalaryCalculator managerSalaryCalculator, ISalesmanSalaryCalculator salesmanSalaryCalculator)
        {
            this.managerSalaryCalculator = managerSalaryCalculator;
            this.workerSalaryCalculator = workerSalaryCalculator;
            this.salesmanSalaryCalculator = salesmanSalaryCalculator;
        }

        public double CalculateSalary(EmployeeBase employee, DateTime dateFrom, DateTime dateTo)
        {
            if (employee is Worker)
            {
                return workerSalaryCalculator.CalculateSalary(employee, dateFrom, dateTo);
            }
            else if (employee is Manager)
            {
                return managerSalaryCalculator.CalculateSalary(employee, dateFrom, dateTo, this);
            }
            else if(employee is Salesman)
            {
                return salesmanSalaryCalculator.CalculateSalary(employee, dateFrom, dateTo, this);
            }
            else
            {
                throw new ArgumentException("Unable to define salary calculator type");
            }
        }
    }
}
