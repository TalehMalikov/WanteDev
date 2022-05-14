using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WanteDev.Core.DataAccess.Abstraction;

namespace WanteDev.ViewModels.Windows.Main
{
    public class DeveloperMainWindowViewModel : BaseWindowViewModel
    {
        public DeveloperMainWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {
        }
        public Grid CenterGrid { get; set; }
    }
}
