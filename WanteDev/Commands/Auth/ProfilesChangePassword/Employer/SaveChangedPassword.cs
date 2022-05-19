using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.Utils;
using WanteDev.ViewModels.ChangePassword.Employer;

namespace WanteDev.Commands.Auth.ProfilesChangePassword.Employer
{
    public class SaveChangedPassword : BaseCommand
    {
        private readonly ChangePasswordWindowViewModel _viewModel;

        public SaveChangedPassword(ChangePasswordWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Employer.PasswordHash = SecurityUtil.ComputeSha256Hash(_viewModel.PasswordToConfirm);
        }
    }
}
