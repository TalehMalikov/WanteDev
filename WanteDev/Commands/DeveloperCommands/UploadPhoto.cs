using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WanteDev.ViewModels.Windows;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.Commands.DeveloperCommands
{
    public class UploadPhoto : BaseCommand
    {
        private readonly DeveloperRegistrationWindowViewModel _viewModel;
        public UploadPhoto(DeveloperRegistrationWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            byte[] ImageArray = new byte[] { };
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            openFileDialog1.ShowDialog();
            openFileDialog1.DefaultExt = ".jpeg";
            // textBox1.Text = openFileDialog1.FileName;
            if (openFileDialog1.FileName == string.Empty)
                return;
            _viewModel.ProfileImageSource = new BitmapImage(new Uri(openFileDialog1.FileName));
            ImageArray = File.ReadAllBytes(openFileDialog1.FileName);
            _viewModel.IsImageSet = true;
            _viewModel.CurrentValue.Photo = ImageArray;
        }

    }
}
