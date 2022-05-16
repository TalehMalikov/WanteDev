using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanteDev.Core.DataAccess.Abstraction;

namespace WanteDev.ViewModels
{
    public class MainWindowViewModel:BaseWindowViewModel
    {
        public MainWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {

        }
    }
}
