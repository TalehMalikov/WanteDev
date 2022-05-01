using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Infrasturcture;

namespace WanteDev.ViewModels
{
    public class BaseWindowViewModel : BaseViewModel
    {

        public IUnitOfWork DB { get; }
        public DataProvider DataProvider { get; }
        public Window Window { get; set; }
        public Grid CenterGrid { get; set; }

        public BaseWindowViewModel(Window window, IUnitOfWork db)
        {
            DB = db;
            DataProvider = new DataProvider(db);
            Window = window;
        }
    }
}
