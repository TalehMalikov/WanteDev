using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;

namespace WanteDev.ViewModels.Windows
{
    public class EmployerRegistrationWindowViewModel : BaseWindowViewModel
    {
        public EmployerRegistrationWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {
        }


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
        private ImageSource profileImageSource = new BitmapImage(new Uri(@"pack://application:,,,/WanteDev;component/Images/avatar.png"));

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


        private EmployerModel currentValue = new EmployerModel();
        public EmployerModel CurrentValue
        {
            get
            {
                if (!isImageSet)
                {
                    CurrentValue.Photo = File.ReadAllBytes(@"/Images/avatar.png");
                }
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
