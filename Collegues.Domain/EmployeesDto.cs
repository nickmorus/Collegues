using Collegues.DatabaseModels;
using Collegues.Domain.Abstract;
using Collegues.Domain.Collegues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegues.Domain
{
    public static class EmployeesDto
    {
        public static EmployeeBase GetEmployee(Employee employee)
        {
            if(employee.Type == EmployeeType.Worker)
            {
                Worker worker = new Worker(employee.FirstName, employee.LastName, employee.FamilyName, employee.EmployementFrom);
                return worker;
            }
            else if(employee.Type == EmployeeType.Salesman)
            {
                Salesman salesman = new Salesman(employee.FirstName, employee.LastName, employee.FamilyName, employee.EmployementFrom);
                salesman.Subordinates = employee.Subordinates.Select(x=>GetEmployee(x)).ToList();
                return salesman;
            }
            else if (employee.Type == EmployeeType.Manager)
            {
                Manager manager = new Manager(employee.FirstName, employee.LastName, employee.FamilyName, employee.EmployementFrom);
                manager.Subordinates = employee.Subordinates.Select(x => GetEmployee(x)).ToList();
                return manager;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
