using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WanteDev.Commands.Auth;
using WanteDev.Commands.DeveloperCommand;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;

namespace WanteDev.ViewModels.Windows
{
    public class DeveloperRegistrationWindowViewModel : BaseWindowViewModel
    {
        public DeveloperRegistrationWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {

        }

        public ICommand Add => new SaveDeveloperCommand(this);

        public ICommand UploadCv => new UploadCv(this);

        public ICommand UploadPhoto => new UploadImage(this);


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
                if (!isImageSet)
                {
                    currentValue.Photo = File.ReadAllBytes(@"\Images\avatar.jpg");
                }
                return currentValue;
            }
            set
            {
                currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }




        //private Visibility passwordErrorVisibility;

        //public Visibility PasswordErrorVisibility
        //{
        //    get { return passwordErrorVisibility; }
        //    set { passwordErrorVisibility = value; }
        //}


        //private string passwordText;
        //public string PasswordText
        //{
        //    get { return passwordText; }
        //    set { passwordText = value; }
        //}

    }
}
