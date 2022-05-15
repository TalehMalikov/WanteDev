using System.Windows;
using System.Windows.Controls;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.Domain.Entities;
using WanteDev.Core.Utils;
using WanteDev.Infrasturcture;
using WanteDev.Mappers;
using WanteDev.ViewModels.Windows.Login;
using WanteDev.ViewModels.Windows.Main;
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
            Developer developereuser = null;
            Employer employeruser = null;
            if (admineuser==null)
                 developereuser = viewModel.DB.DeveloperRepository.Get(viewModel.Email);
            if(developereuser==null)
                 employeruser = viewModel.DB.EmployerRepository.Get(viewModel.Email);

            if (admineuser == null && employeruser == null && developereuser == null)
            {
                viewModel.LoginErrorVisibility = Visibility.Visible;
                return;
            }

            string password = "Kamilova12@";//passwordBox.Password;

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
                EmployerMainWindow employerMainWindow = new EmployerMainWindow();
                EmployerMainWindowViewModel employerMainWindowViewModel = new EmployerMainWindowViewModel(employerMainWindow, Kernel.DB);

                viewModel.Window.Close();

                Kernel.CurrentEmployer = Kernel.DB.EmployerRepository.Get(employeruser.Id);

                employerMainWindowViewModel.CurrentEmployer = new EmployerMapper().Map(Kernel.CurrentEmployer);
                employerMainWindowViewModel.CenterGrid = employerMainWindow.grdCenter;
                employerMainWindow.DataContext = employerMainWindowViewModel;
                employerMainWindow.Show();
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
