using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WantedDev.Core.Domain.Entities;
using WanteDev.Views.Controls;
using WanteDev.Views.Windows.Login;

namespace WanteDev.Views.Windows.Main
{
    /// <summary>
    /// Interaction logic for EmployerMainWindow.xaml
    /// </summary>
    public partial class EmployerMainWindow : Window
    {
        public EmployerMainWindow()
        {
            InitializeComponent();
        }
        private void OnCloseClicked(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
