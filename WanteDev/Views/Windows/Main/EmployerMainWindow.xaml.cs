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

        private void ComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ComboBox? combobox = sender as ComboBox;
            if (combobox?.Name == "cmb_Backend")
                cmb_Backend.Text = "Backend";
            else if (combobox?.Name == "cmb_Frontend")
                cmb_Frontend.Text = "Frontend";
            else if (combobox?.Name == "cmb_MobileDevelopment")
                cmb_MobileDevelopment.Text = "Mobile Development";
            else if (combobox?.Name == "cmb_Fullstack")
                cmb_Fullstack.Text = "Fullstack";
            else if (combobox?.Name == "cmb_Cloud")
                cmb_Cloud.Text = "Cloud";
            else if (combobox?.Name == "cmb_CyberSecurity")
                cmb_CyberSecurity.Text = "Cyber Security";
            else if (combobox?.Name == "cmb_DBA")
                cmb_DBA.Text = "DBA";
            else if (combobox?.Name == "cmb_DataScience")
                cmb_DataScience.Text = "Data Science";
            else if (combobox?.Name == "cmb_GameDevelopment")
                cmb_GameDevelopment.Text = "Game Development";
            else if (combobox?.Name == "cmb_MachineLearning")
                cmb_MachineLearning.Text = "Machine Learning";
            else if (combobox?.Name == "cmb_NetworkAdminstration")
                cmb_NetworkAdminstration.Text = "Network Administration";
            else if (combobox?.Name == "cmb_UXUI")
                cmb_UXUI.Text = "UX/UI";
        }
    }
}
