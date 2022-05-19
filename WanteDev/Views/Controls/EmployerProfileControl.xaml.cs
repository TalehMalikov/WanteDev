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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WanteDev.Views.Controls
{
    /// <summary>
    /// Interaction logic for EmployerProfileControl.xaml
    /// </summary>
    public partial class EmployerProfileControl : UserControl
    {
        public EmployerProfileControl()
        {
            InitializeComponent();
        }
        //private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        //{
        //    passwordTxtBox.Text = passwordTxt.Password;
        //    passwordTxt.Visibility = Visibility.Collapsed;
        //    passwordTxtBox.Visibility = Visibility.Visible;
        //}

        //private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    passwordTxt.Password = passwordTxtBox.Text;
        //    passwordTxtBox.Visibility = Visibility.Collapsed;
        //    passwordTxt.Visibility = Visibility.Visible;
        //}
        private void btnRegisterInClick(object sender, RoutedEventArgs e)
        {
            //if (showPassword.IsChecked == true)
            //{
            //    passwordTxt.Password = passwordTxtBox.Text;
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
