using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanteDev.Core.DataAccess.Abstraction;

namespace WanteDev.ViewModels.Windows
{
    public class EmployerRegistrationWindowViewModel : BaseWindowViewModel
    {
        public EmployerRegistrationWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {
        }
    }
}
