using Collegues.DatabaseModels;
using Collegues.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegues.Database
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly EmployeesDbContext context;
        public EmployeesRepository(EmployeesDbContext context)
        {
            this.context = context;
        }

        public List<Employee> GetAll() => context.Employees.ToList();
        public Employee? GetById(int id) => context.Employees.FirstOrDefault(e => e.Id == id);
        
    }
}
