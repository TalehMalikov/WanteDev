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

namespace WanteDev.Views.Windows.Login
{
    /// <summary>
    /// Interaction logic for EmployerRegistrationWindow.xaml
    /// </summary>
    public partial class EmployerRegistrationWindow : Window
    {
        public EmployerRegistrationWindow()
        {
            InitializeComponent();
        }
        private void OnCloseClicked(object sender, EventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            passwordTxtBox.Text = passwordTxt.Password;
            passwordTxt.Visibility = Visibility.Collapsed;
            passwordTxtBox.Visibility = Visibility.Visible;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordTxt.Password = passwordTxtBox.Text;
            passwordTxtBox.Visibility = Visibility.Collapsed;
            passwordTxt.Visibility = Visibility.Visible;
        }
    }
}
