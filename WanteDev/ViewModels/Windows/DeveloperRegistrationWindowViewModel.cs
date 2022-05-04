using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WanteDev.Commands.Auth;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;

namespace WanteDev.ViewModels.Windows
{
    public class DeveloperRegistrationWindowViewModel : BaseWindowViewModel
    {
        public DeveloperRegistrationWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {

        }

        public DeveloperModel CurrentValue { get; set; } = new DeveloperModel();
        public ICommand Add => new SaveDeveloperCommand(this);

        //private Visibility passwordErrorVisibility;

        //public Visibility PasswordErrorVisibility
        //{
        //    get { return passwordErrorVisibility; }
        //    set { passwordErrorVisibility = value; }
        //}


        //private string passwordText;
        //public string PasswordText
        //{
        //    get { return passwordText; }
        //    set { passwordText = value; }
        //}

    }
}
