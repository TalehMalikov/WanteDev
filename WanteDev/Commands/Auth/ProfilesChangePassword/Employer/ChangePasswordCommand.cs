using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Infrasturcture;
using WanteDev.ViewModels.ChangePassword.Employer;
using WanteDev.ViewModels.Controls;
using ChangePasswordInProfileWindow = WanteDev.ViewModels.Windows.ChangePassword.Employer.ChangePasswordInProfileWindow;

namespace WanteDev.Commands.Auth.ProfilesChangePassword.Employer
{
    public class ChangePasswordCommand : BaseCommand
    {
        private readonly EmployerProfileControlViewModel _viewModel;
        public ChangePasswordCommand(EmployerProfileControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            ChangePasswordInProfileWindow window = new ChangePasswordInProfileWindow();
            ChangePasswordWindowViewModel viewModel = new ChangePasswordWindowViewModel(window, Kernel.DB, _viewModel);
            window.DataContext = viewModel;
            window.Show();

        }
    }
}
