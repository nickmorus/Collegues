using Colegues.Business.Calculators;
using Collegues.Database;
using Collegues.DatabaseModels;
using Collegues.Domain;
using Collegues.Domain.Abstract;
using Collegues.Domain.Abstract.Calculators;
using Collegues.Views;
using DryIoc;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Collegues.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public IEmployeeSalaryCalculator employeeSalaryCalculator;
        public IWorkerSalaryCalculator workerSalaryCalculator;
        public ISalesmanSalaryCalculator salesmanSalaryCalculator;
        public IManagerSalaryCalculator managerSalaryCalculator;
        public IEmployeesRepository employeesRepository;

        public MainViewModel(IContainerProvider container)
        {
            workerSalaryCalculator = container.Resolve<IWorkerSalaryCalculator>();
            salesmanSalaryCalculator = container.Resolve<ISalesmanSalaryCalculator>();
            managerSalaryCalculator = container.Resolve<IManagerSalaryCalculator>();
            employeesRepository = container.Resolve<IEmployeesRepository>();
            employeeSalaryCalculator = container.Resolve<IEmployeeSalaryCalculator>();

            Employees.AddRange(employeesRepository.GetAll());
        }


        private DateTime dateEnd = DateTime.Now;
        private int selectedEmployeeIdx;
        private bool toNow;

        public DateTime DateEnd { get => dateEnd; set => SetProperty(ref dateEnd, value); }
        public ObservableCollection<Employee> Employees { set; get; } = new();
        public int SelectedEmployeeIdx { get => selectedEmployeeIdx; set => SetProperty(ref selectedEmployeeIdx, value); }
        public bool ToNow { get => toNow; set => SetProperty(ref toNow, value); }


        public ICommand CalculatePersonSalaryCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (selectedEmployeeIdx != -1)
                    {
                        EmployeeBase employee = EmployeesDto.GetEmployee(Employees[selectedEmployeeIdx]);
                        MessageBox.Show($"Заработная плата: {employeeSalaryCalculator.CalculateSalary(employee, employee.EmploymentFrom, DateEnd)}");
                    }
                });
            }
        }
        public ICommand CalculateOverallSalaryCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    double totalSum = 0;
                    foreach(var empl in employeesRepository.GetAll())
                    {
                        EmployeeBase employee = EmployeesDto.GetEmployee(empl);
                        totalSum += employeeSalaryCalculator.CalculateSalary(employee, employee.EmploymentFrom, DateEnd);
                    }
                    MessageBox.Show($"Общая заработная плата: {totalSum}");
                });
            }
        }
        public ICommand ShowSubordinatesCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (selectedEmployeeIdx != -1)
                    {
                        Employee employee = Employees[selectedEmployeeIdx];
                        if(employee.Subordinates != null)
                        {
                            Subordinates subordinatesView = new();
                            (subordinatesView.DataContext as SubordinatesViewModel)!.Subordinates = 
                                new ObservableCollection<Employee>(employee.Subordinates);
                        }
                        else
                        {
                            MessageBox.Show("Подчиненных нет");
                        }
                    }
                });
            }
        }
        public ICommand AddEmployeeCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {

                });
            }
        }
        public ICommand RemoveSelectedEmployee
        {
            get
            {
                return new DelegateCommand(() =>
                {

                });
            }
        }
    }
}
