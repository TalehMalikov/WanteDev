using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Infrasturcture;
using WanteDev.ViewModels.Windows.Login;
using WanteDev.Views.Windows.Login;

namespace WanteDev.Commands.Main
{
    public class OpenEmployerRegistrationCommand : BaseCommand
    {
        private RegistrationWindowViewModel _viewModel { get; set; }
        public OpenEmployerRegistrationCommand(RegistrationWindowViewModel viewModel)
        {
            _viewModel= viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Window.Close();

            EmployerRegistrationWindow employerRegistrationWindow = new EmployerRegistrationWindow();

            EmployerRegistrationWindowViewModel employerWindowViewModel = new EmployerRegistrationWindowViewModel(employerRegistrationWindow, Kernel.DB);

            employerRegistrationWindow.DataContext = employerWindowViewModel;
            employerRegistrationWindow.Show();
        }
    }
}
