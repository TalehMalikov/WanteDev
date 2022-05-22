using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WanteDev.Commands.Auth;
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
        public ICommand Add => new SaveDeveloperCommand(this);

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


        #region LanguageProperties

        private ObservableCollection<ProgrammingLanguageModel> _alllangauge;

        public ObservableCollection<ProgrammingLanguageModel> AllProgrammingLanguages
        {
            get 
            { 
                return _alllangauge; 
            }
            set 
            {
                _alllangauge = value;
            }
        }


        private ProgrammingLanguageModel _selectedlangauge;

        public ProgrammingLanguageModel SelectedProgrammingLanguage
        {
            get
            {
                return _selectedlangauge;
            }
            set
            {
                _selectedlangauge = value;
                if(value!=null)
                {
                    AllAddedProgrammingLanguages.Add(_selectedlangauge);
                    AllProgrammingLanguages.Remove(_selectedlangauge);
                }
                OnPropertyChanged(nameof(SelectedProgrammingLanguage));
            }
        }

        private ObservableCollection<ProgrammingLanguageModel> _alladdedlangauge = new ObservableCollection<ProgrammingLanguageModel>();

        public ObservableCollection<ProgrammingLanguageModel> AllAddedProgrammingLanguages
        {
            get
            {
                return _alladdedlangauge;
            }
            set
            {
                _alladdedlangauge = value;
            }
        }

        private ProgrammingLanguageModel _selectedaddedlangauge;

        public ProgrammingLanguageModel SelectedAddedProgrammingLanguage
        {
            get
            {
                return _selectedaddedlangauge;
            }
            set
            {
                _selectedaddedlangauge = value;
                if (value != null)
                {
                    AllAddedProgrammingLanguages.Remove(_selectedaddedlangauge);
                    AllProgrammingLanguages.Add(_selectedaddedlangauge);
                }
                OnPropertyChanged(nameof(SelectedAddedProgrammingLanguage));
            }
        }

        
        #endregion
    }
}
