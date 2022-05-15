using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WanteDev.Commands.Auth;
using WanteDev.Commands.Main;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.ViewModels.Windows.Main
{
    public class EmployerMainWindowViewModel : BaseWindowViewModel
    {
        public EmployerMainWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {
        }
        // example : OpenPrivateInformationCommand
        public EmployerModel CurrentEmployer { get; set; }

        public OpenMainWindowCommand OpenMainWindow => new OpenMainWindowCommand(this);
        public OpenEmployerProfileCommand OpenEmployerProfile => new OpenEmployerProfileCommand(this);
        public Grid CenterGrid { get; set; }





        private ObservableCollection<DeveloperModel> allDevelopers;

        public ObservableCollection<DeveloperModel> AllDevelopers
        {
            get 
            { 
                return allDevelopers; 
            }

            set 
            {
                allDevelopers = value;
            }
        }


    }
}
