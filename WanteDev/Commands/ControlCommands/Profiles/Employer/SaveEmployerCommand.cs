using System;
using System.Windows;
using System.Windows.Controls;
using WanteDev.Core.Utils;
using WanteDev.Infrasturcture;
using WanteDev.Mappers;
using WanteDev.Utils;
using WanteDev.ViewModels.Controls;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.Commands.ControlCommands.Profiles.Employer
{
    public class SaveEmployerCommand : BaseCommand
    {
        private readonly EmployerProfileControlViewModel _viewModel;

        public SaveEmployerCommand(EmployerProfileControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            Save(parameter);
        }

        private void Save(object param)
        {
            DataValidator dataValidator = new DataValidator(_viewModel.DB);
            try
            {
                UserDefaultFiller.Fill(_viewModel.CurrentValue);
                EmployerMapper mapper = new EmployerMapper();

                var employer = mapper.Map(_viewModel.CurrentValue);
                //PasswordBox password = param as PasswordBox;
                //_viewModel.CurrentValue.PasswordHash = password?.Password;
                employer.ModifiedDate = DateTime.Now;
                if (dataValidator.IsDeveloperValid(_viewModel.CurrentValue, out string message) == false)
                {
                    MessageBox.Show(message, "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                //  employer.PasswordHash = SecurityUtil.ComputeSha256Hash(password.Password);
                // _viewModel.CurrentValue.PasswordHash = employer.PasswordHash;

                if (employer.Id != 0)
                {
                    _viewModel.DB.EmployerRepository.Update(employer);
                }
                else
                {
                    _viewModel.DB.EmployerRepository.Add(employer);
                }
                MessageBox.Show("Operation completed successfully", "Registration is successfully!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
