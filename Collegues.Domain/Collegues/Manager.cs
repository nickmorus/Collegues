using Collegues.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegues.Domain.Collegues
{
    public class Manager : EmployeeBase, IBoss
    {
        public List<EmployeeBase> Subordinates { set; get; } = new();

        public Manager(string firstName, string? lastName, string familyName, DateTime employmentFrom) 
            : base(firstName, lastName, familyName, employmentFrom)
        {
        }
    }
}
