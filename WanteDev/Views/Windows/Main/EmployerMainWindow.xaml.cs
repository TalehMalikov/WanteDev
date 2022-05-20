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
            App.Current.Shutdown(); 
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textbox = sender as TextBox;
            if (textbox?.Text == "Firstname")
                textbox_Firstname.Text = "";
            else if (textbox?.Text == "Lastname")
                textbox_Lastname.Text = "";
            else if (textbox?.Text == "Email")
                textbox_Email.Text = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textbox = sender as TextBox;
            if (textbox?.Text == "" && textbox?.Name== "textbox_Firstname")
                textbox_Firstname.Text = "Firstname";
            else if (textbox?.Text == "" && textbox?.Name == "textbox_Lastname")
                textbox_Lastname.Text = "Lastname";
            else if (textbox?.Text == "" && textbox?.Name == "textbox_Email")
                textbox_Email.Text = "Email";
        }
    }
}
