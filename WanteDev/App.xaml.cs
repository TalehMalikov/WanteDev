using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WantedDev.Core.Domain.Enums;
using WanteDev.Core.Factories;
using WanteDev.Core.Utils;
using WanteDev.Infrasturcture;
using WanteDev.ViewModels.Windows.Login;
using WanteDev.Views.Windows.Login;

namespace WanteDev
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DBWanteDev"].ConnectionString;
            Kernel.DB = DBFactory.Create(ServerType.MsSql, connectionString);
            LoginWindow loginWindow = new();
            LoginWindowViewModel viewModel = new(loginWindow, Kernel.DB);
            loginWindow.DataContext = viewModel;
            loginWindow.Show();
        }
    }
}
