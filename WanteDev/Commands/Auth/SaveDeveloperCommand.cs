using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using Microsoft.VisualBasic.CompilerServices;
using WanteDev.Core.Utils;
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
            try
            {
                DeveloperMapper developerMapper = new DeveloperMapper();
                var developer = developerMapper.Map(_viewModel.CurrentValue);
                PasswordBox password = param as PasswordBox;
                developer.PasswordHash = SecurityUtil.ComputeSha256Hash(password.Password);
                if (developer.Id != 0)
                {
                    _viewModel.DB.DeveloperRepository.Update(developer);
                }
                else
                {
                    _viewModel.DB.DeveloperRepository.AddDeveloper(developer);
                }
                MessageBox.Show("Successfully!");
                _viewModel.Window.Close();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }

        }
    }
}
