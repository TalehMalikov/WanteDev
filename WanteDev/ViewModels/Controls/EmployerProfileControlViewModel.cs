using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WanteDev.Commands.ControlCommands.Profiles.Employer;
using WanteDev.Commands.EmployerCommands;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;
using WanteDev.ViewModels.Windows.Login;
using WanteDev.ViewModels.Windows.Main;
using UploadPhoto = WanteDev.Commands.ControlCommands.Profiles.Employer.UploadPhoto;

namespace WanteDev.ViewModels.Controls
{
    public class EmployerProfileControlViewModel : BaseControlViewModel<EmployerModel>
    {
       //// public EmployerModel Model { get; }

        public EmployerProfileControlViewModel(IUnitOfWork db,EmployerModel model) : base(db)
        {
           // Model = model;
            CurrentValue = model;
            EmployerRegistrationWindowViewModel = new EmployerRegistrationWindowViewModel(new Window(), db);
            EmployerRegistrationWindowViewModel.CurrentValue = model;
        }

        private readonly EmployerRegistrationWindowViewModel EmployerRegistrationWindowViewModel;

        public ICommand UploadPhoto => new UploadPhoto(this);

        public SaveEmployerCommand Add => new SaveEmployerCommand(this);

        public  void Initialize()
        {
        }
    }
}
