using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.ViewModels.Windows;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.Commands.DeveloperCommands
{

    public class UploadCv : BaseCommand
    {
        private readonly DeveloperRegistrationWindowViewModel _viewModel;
        public UploadCv(DeveloperRegistrationWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            byte[] CvArray = new byte[] { };
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf";
            openFileDialog1.ShowDialog();
            openFileDialog1.DefaultExt = ".jpeg";
            // textBox1.Text = openFileDialog1.FileName;
            if (openFileDialog1.FileName == string.Empty)
                return;
            CvArray = File.ReadAllBytes(openFileDialog1.FileName);
            _viewModel.CurrentValue.CV = CvArray;
        }
    }
}

