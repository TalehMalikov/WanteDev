using System.Windows;
using System.Windows.Controls;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.Domain.Entities;
using WanteDev.Core.Utils;
using WanteDev.ViewModels.Windows;
using WanteDev.Views.Windows.Main;

namespace WanteDev.Commands.Auth
{
    public class LoginCommand : BaseCommand
    {
        private readonly LoginWindowViewModel viewModel;
        public LoginCommand(LoginWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            PasswordBox? passwordBox = parameter as PasswordBox;

            if (passwordBox == null)
                return;

            // admin, employer,user : 

            Admin admineuser = viewModel.DB.AdminRepository.Get(viewModel.Email);
            Employer employeruser = viewModel.DB.EmployerRepository.Get(viewModel.Email);
            Developer developereuser = viewModel.DB.DeveloperRepository.Get(viewModel.Email);

            if (admineuser == null && employeruser == null && developereuser == null)
            {
                viewModel.LoginErrorVisibility = Visibility.Visible;
                return;
            }

            string password = passwordBox.Password;

            string passwordHash = SecurityUtil.ComputeSha256Hash(password);

            if (admineuser?.PasswordHash == passwordHash) //&& user.Role == Role.Admin)
            {
                // main admin window show 

            }
            else if (developereuser?.PasswordHash == passwordHash)// && user.Role == Role.User)
            {


                DeveloperMainWindow developerMain = new DeveloperMainWindow();
                developerMain.DataContext = new object(); // --- appropriate viewModel
                developerMain.Show();

                // main developer window show
            }
            else if (employeruser?.PasswordHash == passwordHash)// && user.Role == Role.User)
            {
               //
            }
            else
            {
                viewModel.LoginErrorVisibility = Visibility.Visible;
                return;
            }
        }
    }
}
