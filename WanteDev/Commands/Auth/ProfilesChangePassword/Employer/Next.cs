using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanteDev.Core.Utils;
using WanteDev.ViewModels.ChangePassword.Employer;
using WanteDev.ViewModels.Controls;

namespace WanteDev.Commands.Auth.ProfilesChangePassword.Employer
{
    public class Next : BaseCommand
    {
        private readonly ChangePasswordWindowViewModel _viewModel;

        public Next(ChangePasswordWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(SecurityUtil.ComputeSha256Hash(_viewModel.UserEnteredPreviousPassword)==_viewModel.Employer.PasswordHash)
            {
                _viewModel.FirstStackPanelVisibility = Visibility.Hidden;
                _viewModel.SecondStackPanelVisibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Password is incorrect");
            }
        }
    }
}
