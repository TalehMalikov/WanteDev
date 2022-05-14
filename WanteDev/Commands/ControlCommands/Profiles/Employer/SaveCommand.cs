using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WanteDev.Core.Utils;
using WanteDev.Mappers;
using WanteDev.ViewModels.Controls;

namespace WanteDev.Commands.ControlCommands.Profiles.Employer
{
    public class SaveCommand : BaseCommand
    {
        public EmployerProfileControlViewModel _viewModel { get; set; }
        public SaveCommand(EmployerProfileControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            Save(parameter);
        }
        private void Save(object parameter)
        {
            try
            {
                EmployerMapper employerMapper = new EmployerMapper();
                var employer = employerMapper.Map(_viewModel.CurrentValue);
                PasswordBox password = parameter as PasswordBox;
                employer.PasswordHash = SecurityUtil.ComputeSha256Hash(password.Password);
                if (employer.Id != 0)
                {
                    _viewModel.DB.EmployerRepository.Update(employer);
                }
                else
                {
                    _viewModel.DB.EmployerRepository.Add(employer);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
