using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WanteDev.Commands.DeveloperCommands;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;

namespace WanteDev.ViewModels.Windows.Login
{
    public class DeveloperRegistrationWindowViewModel : BaseWindowViewModel
    {
        public DeveloperRegistrationWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {
        }
        public ICommand UploadPhoto => new UploadPhoto(this);

        public ICommand UploadCv => new UploadCv(this);
        private bool isImageSet;
        public bool IsImageSet
        {
            set
            {
                isImageSet = value;
                OnPropertyChanged(nameof(IsImageSet));
            }
            get
            {
                return isImageSet;

            }
        }
        private ImageSource profileImageSource = new BitmapImage(new Uri(@"pack://application:,,,/WanteDev;component/Images/avatar.jpg"));

        public ImageSource ProfileImageSource
        {
            get
            {
                return profileImageSource;
            }
            set
            {
                profileImageSource = value;
                OnPropertyChanged(nameof(ProfileImageSource));
            }
        }


        private DeveloperModel currentValue = new();
        public DeveloperModel CurrentValue
        {
            get
            {
                //if (!isImageSet)
                //{
                //    currentValue.Photo = File.ReadAllBytes(@"\Images\avatar.jpg");
                //}
                return currentValue;
            }
            set
            {
                currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }
    }
}
