using Colegues.Business;
using Colegues.Business.Calculators;
using Collegues.Database;
using Collegues.Domain.Abstract;
using Collegues.Domain.Abstract.Calculators;
using Collegues.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Collegues
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()=> Container.Resolve<Main>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IWorkerSalaryCalculator>(() => new WorkerSalaryCalculator(120, 1.4, 0.03));
            containerRegistry.RegisterSingleton<ISalesmanSalaryCalculator>(() => new SalesmanSalaryCalculator(0,0,0,0));
            containerRegistry.RegisterSingleton<IManagerSalaryCalculator>(() => new ManagerSalaryCalculator(0,0,0,0));
            containerRegistry.RegisterSingleton<IEmployeeSalaryCalculator, ColleguesSalaryCalculator>();

            DbContextOptionsBuilder builder = new();
            builder.UseSqlite("Data Source=c:\\mydb.db;Version=3;");
            EmployeesDbContext context = new EmployeesDbContext(builder.Options);

            containerRegistry.Register<EmployeesDbContext>(()=>context);
            containerRegistry.Register<IEmployeesRepository, EmployeesMockRepository>();
        }
    }
}
