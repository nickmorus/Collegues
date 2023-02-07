using Collegues.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegues.Domain.Collegues
{
    public class Salesman: EmployeeBase
    {
        public List<EmployeeBase> Subordinates { set; get; } = new();

        public Salesman(string firstName, string? lastName, string familyName, DateTime employmentFrom) 
            : base(firstName, lastName, familyName, employmentFrom)
        {
        }
    }
}
