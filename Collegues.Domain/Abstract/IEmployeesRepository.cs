using Collegues.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegues.Domain.Abstract
{
    public interface IEmployeesRepository
    {
        public Employee? GetById(int id);
        public List<Employee> GetAll();
    }
}
