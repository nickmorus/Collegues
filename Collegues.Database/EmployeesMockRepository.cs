using Collegues.DatabaseModels;
using Collegues.Domain.Abstract;
using Collegues.Domain.Collegues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegues.Database
{
    public class EmployeesMockRepository : IEmployeesRepository
    {
        public List<Employee> GetAll()
        {
            return new List<Employee>()
            {
                new Employee(){Id=1, FirstName="Nick", LastName="Ivanovich", FamilyName="Perov", EmployementFrom=new DateTime(2021,1,22)}
            };
        }

        public Employee? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
