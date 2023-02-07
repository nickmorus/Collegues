using Collegues.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegues.Domain.Abstract
{
    public interface IBoss
    {
        List<EmployeeBase> Subordinates { set; get; }
    }
}
