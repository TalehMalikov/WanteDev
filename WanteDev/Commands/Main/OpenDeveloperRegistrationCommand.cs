using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Infrasturcture;
using WanteDev.ViewModels.Windows;
using WanteDev.Views.Windows;

namespace WanteDev.Commands.Main
{
    public class OpenDeveloperRegistrationCommand : BaseCommand
    {
        private RegistrationWindowViewModel _viewModel { get; set; }
        public OpenDeveloperRegistrationCommand(RegistrationWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Window.Close();

            DeveloperRegistrationWindow developerRegistrationWindow = new DeveloperRegistrationWindow();

            DeveloperRegistrationWindowViewModel developerWindowViewModel = new DeveloperRegistrationWindowViewModel(developerRegistrationWindow, Kernel.DB);
            developerRegistrationWindow.DataContext = developerWindowViewModel;
            developerRegistrationWindow.Show();
        }
    }
}
