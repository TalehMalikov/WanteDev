using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WanteDev.Infrasturcture;
using WanteDev.ViewModels.Windows;
using WanteDev.Views.Windows;

namespace WanteDev.Commands.Auth
{
    public class RegistrationCommand : BaseCommand
    {
        private readonly LoginWindowViewModel viewModel;
        public RegistrationCommand(LoginWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {

            RegistrationWindow registrationWindow = new RegistrationWindow();
            //viewModel.Window.Close();

            RegistrationWindowViewModel registrationWindowViewModel = new RegistrationWindowViewModel(registrationWindow, Kernel.DB);
            registrationWindow.DataContext = registrationWindowViewModel;
            registrationWindow.Show();
        }
    }
}
