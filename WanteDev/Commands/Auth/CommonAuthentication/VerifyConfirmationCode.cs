using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.Commands.Auth.CommonAuthentication
{
    public class VerifyConfirmationCode : BaseCommand
    {
        readonly LoginWindowViewModel viewModel;
        public VerifyConfirmationCode(LoginWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            if (viewModel.UserEnteredConfirmationCode == null)
            {
                viewModel.NullCodeVisibility = Visibility.Visible;
                return;
            }
            else if (viewModel.UserEnteredConfirmationCode == viewModel.ConfirmationCode)
            {
                viewModel.SecondStackPanelVisibility = Visibility.Collapsed;
                
                viewModel.IncorrectCodeVisibility = Visibility.Collapsed;
                viewModel.NullCodeVisibility = Visibility.Collapsed;
                viewModel.ThirdStackPanelVisibility = Visibility.Visible;
                return;
            }
            else
            {
                viewModel.IncorrectCodeVisibility = Visibility.Visible;
                return;
               // Error Mes
               // sage
               // viewModel. = Constants.ErrorMessage;
            }
        }
    }
}
