using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.Domain.Entities;
using WanteDev.Core.Utils;
using WanteDev.Infrasturcture;
using WanteDev.Mappers;
using WanteDev.Models;
using WanteDev.ViewModels.Windows.Login;
using WanteDev.ViewModels.Windows.Main;
using WanteDev.Views.Windows.Main;

namespace WanteDev.Commands.Auth
{
    public class LoginCommand : BaseCommand
    {
        private readonly LoginWindowViewModel _viewModel;
        public LoginCommand(LoginWindowViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            PasswordBox? passwordBox = parameter as PasswordBox;

            if (passwordBox == null)
                return;

            // admin, employer,user : 

            Admin admineuser = _viewModel.DB.AdminRepository.Get(_viewModel.Email);
            Developer developereuser = null;
            Employer employeruser = null;
            if (admineuser==null)
                 developereuser = _viewModel.DB.DeveloperRepository.Get(_viewModel.Email);
            if(developereuser==null)
                 employeruser = _viewModel.DB.EmployerRepository.Get(_viewModel.Email);

            if (admineuser == null && employeruser == null && developereuser == null)
            {
                _viewModel.LoginErrorVisibility = Visibility.Visible;
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
                developerMain.DataContext = new object(); // --- appropriate _viewModel
                developerMain.Show();

                // main developer window show
            }
            else if (employeruser?.PasswordHash == passwordHash)// && user.Role == Role.User)
            {
                EmployerMainWindow employerMainWindow = new EmployerMainWindow();
                EmployerMainWindowViewModel employerMainWindowViewModel = new EmployerMainWindowViewModel(employerMainWindow, Kernel.DB);

                _viewModel.Window.Close();

                Kernel.CurrentEmployer = Kernel.DB.EmployerRepository.Get(employeruser.Id);

                employerMainWindowViewModel.CurrentEmployer = new EmployerMapper().Map(Kernel.CurrentEmployer);
                employerMainWindowViewModel.CenterGrid = employerMainWindow.grdCenter;
                employerMainWindowViewModel.AllProgrammingLanguages = _viewModel.DataProvider.GetProgrammingLanguages();
                employerMainWindowViewModel.AllDevelopers = new ObservableCollection<DeveloperModel>(_viewModel.DataProvider.GetDevelopersForSearch());
                employerMainWindow.DataContext = employerMainWindowViewModel;
                employerMainWindow.Show();
            }
            else
            {
                _viewModel.LoginErrorVisibility = Visibility.Visible;
                return;
            }
        }
    }
}
