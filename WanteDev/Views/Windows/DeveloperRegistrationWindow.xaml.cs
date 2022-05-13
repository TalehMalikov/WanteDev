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

namespace WanteDev.Views.Windows
{
    /// <summary>
    /// Interaction logic for DeveloperRegistrationWindow.xaml
    /// </summary>
    public partial class DeveloperRegistrationWindow : Window
    {
        public DeveloperRegistrationWindow()
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
        private void btnRegisterInClick(object sender, RoutedEventArgs e)
        {
            if (showPassword.IsChecked == true)
            {
                passwordTxt.Password = passwordTxtBox.Text;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            GirlPictureStackPanel.Visibility = Visibility.Collapsed;
            FirstStackPanel.Visibility = Visibility.Hidden; // NAME, SURN
            SecondStackPanel.Visibility = Visibility.Visible; // COMPANY
            ThirdStackPanel.Visibility = Visibility.Visible; // SHEKIL BIO CV
        }
    }
}
