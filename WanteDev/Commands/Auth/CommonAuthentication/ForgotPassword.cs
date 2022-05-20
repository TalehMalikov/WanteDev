using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.Commands.Auth.CommonAuthentication
{
    public class ForgotPassword : BaseCommand
    {
        readonly LoginWindowViewModel viewModel;
        public ForgotPassword(LoginWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.LoginWindowVisibility =Visibility.Collapsed;
            viewModel.FirstStackPanelVisibility = Visibility.Visible;
        }
    }
}
