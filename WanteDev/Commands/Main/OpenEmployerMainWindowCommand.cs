using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Infrasturcture;
using WanteDev.Mappers;
using WanteDev.Models;
using WanteDev.ViewModels.Windows.Main;
using WanteDev.Views.Windows.Login;
using WanteDev.Views.Windows.Main;

namespace WanteDev.Commands.Main
{
    public class OpenEmployerMainWindowCommand : BaseCommand
    {

        private readonly EmployerMainWindowViewModel _viewModel;
        public OpenEmployerMainWindowCommand(EmployerMainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            EmployerMainWindow employerMainWindow = new EmployerMainWindow();
            EmployerMainWindowViewModel employerMainWindowViewModel = new EmployerMainWindowViewModel(employerMainWindow, Kernel.DB);
            employerMainWindowViewModel.CurrentEmployer = new EmployerMapper().Map(Kernel.CurrentEmployer);
            employerMainWindowViewModel.CenterGrid = employerMainWindow.grdCenter;
            employerMainWindowViewModel.AllProgrammingLanguages =_viewModel.DataProvider.GetProgrammingLanguages();
            employerMainWindowViewModel.AllDevelopers = new ObservableCollection<DeveloperModel>(_viewModel.DataProvider.GetDevelopersForSearch());
            employerMainWindow.DataContext = employerMainWindowViewModel;
            _viewModel.Window.Close();
            employerMainWindow.Show();
        }
    }
}
