using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WanteDev.Commands.Auth;
using WanteDev.Commands.EmployerCommands;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;

namespace WanteDev.ViewModels.Windows.Login
{
    public class EmployerRegistrationWindowViewModel : BaseWindowViewModel
    {
        public EmployerRegistrationWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {
        }

        public ICommand Add => new SaveEmployerCommand(this);
        public ICommand UploadPhoto => new UploadPhoto(this);

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


        private EmployerModel currentValue = new();
        public EmployerModel CurrentValue
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
