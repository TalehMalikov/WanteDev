using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanteDev.Commands.Main;
using WanteDev.Core.DataAccess.Abstraction;

namespace WanteDev.ViewModels.Windows
{
    public class RegistrationWindowViewModel : BaseWindowViewModel
    {
        public RegistrationWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {
        }
        public OpenEmployerRegistrationCommand OpenEmployerRegistration => new OpenEmployerRegistrationCommand(this);
        public OpenDeveloperRegistrationCommand OpenDeveloperRegistration => new OpenDeveloperRegistrationCommand(this);

        private bool employerChecked;
        public bool EmployerChecked
        {
            get
            {
                return employerChecked;
            }
            set
            {
                employerChecked = value;
                OnPropertyChanged(nameof(EmployerChecked));
            }
        }

        private bool developerChecked;
        public bool DeveloperChecked
        {
            get
            {
                return developerChecked;
            }
            set
            {
                developerChecked = value;
                OnPropertyChanged(nameof(DeveloperChecked));
            }
        }

    }
}
