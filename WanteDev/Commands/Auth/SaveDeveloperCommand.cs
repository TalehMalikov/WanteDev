using System;
using System.Windows;
using System.Windows.Controls;
using WanteDev.Core.Utils;
using WanteDev.Infrasturcture;
using WanteDev.Mappers;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.Commands.Auth
{
    public class SaveDeveloperCommand:BaseCommand
    {
        private readonly DeveloperRegistrationWindowViewModel _viewModel;

        public SaveDeveloperCommand(DeveloperRegistrationWindowViewModel viewModel)
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
                DeveloperMapper developerMapper = new DeveloperMapper();
                var developer = developerMapper.Map(_viewModel.CurrentValue);
                PasswordBox password = param as PasswordBox;
                _viewModel.CurrentValue.PasswordHash = password?.Password;
                developer.ModifiedDate = DateTime.Now;
                //if (dataValidator.IsDeveloperValid(_viewModel.CurrentValue, out string message) == false)
                //{
                //    MessageBox.Show(message, "Validation error", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}
                developer.PasswordHash = SecurityUtil.ComputeSha256Hash(password.Password); 
                _viewModel.CurrentValue.PasswordHash = developer.PasswordHash;
               
                if (developer.Id != 0)
                {
                    _viewModel.DB.DeveloperRepository.Update(developer);
                }
                else
                {
                    _viewModel.DB.DeveloperRepository.Add(developer);
                }
                MessageBox.Show("Operation completed successfully", "Registration is successfully!", MessageBoxButton.OK, MessageBoxImage.Error);
                _viewModel.Window.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
