using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WanteDev.Commands.Main;
using WanteDev.Core.DataAccess.Abstraction;

namespace WanteDev.ViewModels.Windows.Main
{
    public class EmployerMainWindowViewModel : BaseWindowViewModel
    {
        public EmployerMainWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {
        }
        // example : OpenPrivateInformationCommand

        public OpenMainWindowCommand OpenMainWindow => new OpenMainWindowCommand(this);
        public OpenEmployerProfileCommand OpenEmployerProfile => new OpenEmployerProfileCommand(this);
        public Grid CenterGrid { get; set; }
    }
}
