using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Infrasturcture;
using WanteDev.ViewModels.Controls;
using WanteDev.ViewModels.Windows.Main;
using WanteDev.Views.Controls;

namespace WanteDev.Commands.Main
{
    public class OpenEmployerProfileCommand : BaseCommand
    {

        private readonly EmployerMainWindowViewModel _viewModel;
        public OpenEmployerProfileCommand(EmployerMainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.CenterGrid.Children.Clear();

            EmployerProfileControlViewModel employerProfileControlViewModel = new EmployerProfileControlViewModel(Kernel.DB,_viewModel.CurrentEmployer);

           // employerProfileControlViewModel.AllValues = viewModel.DataProvider.GetEmployees();
           // employerProfileControlViewModel.Apartments = new ObservableCollection<ApartmentModel>(viewModel.DataProvider.GetApartments());

           // employerProfileControlViewModel.Initialize();

            EmployerProfileControl employeescontrol = new EmployerProfileControl();
            //employerProfileControlViewModel.ErrorDialog = employeescontrol.ErrorDialog;
            employeescontrol.DataContext = employerProfileControlViewModel;
            _viewModel.CenterGrid.Children.Add(employeescontrol);
        }
    }
}
