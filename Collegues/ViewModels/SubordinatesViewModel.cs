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
    public class SubordinatesViewModel : BindableBase
    {
        public ObservableCollection<Employee> Subordinates { set; get; } = new();
    }
}
