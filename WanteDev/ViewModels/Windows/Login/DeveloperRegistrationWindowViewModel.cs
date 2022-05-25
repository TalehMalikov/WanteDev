using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WanteDev.Commands.Auth;
using WanteDev.Commands.DeveloperCommands;
using WanteDev.Commands.DeveloperCommands.LanguageCommands;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;

namespace WanteDev.ViewModels.Windows.Login
{
    public class DeveloperRegistrationWindowViewModel : BaseWindowViewModel
    {
        public DeveloperRegistrationWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {
            //PropertyChanged += propChangHandler;
        }

        //private void propChangHandler(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    switch (e.PropertyName)
        //    {
        //        case "SelectedProgrammingLanguage":
        //            this.AddToSelected();
        //            break;
        //        case "SelectedAddedProgrammingLanguage":
        //            this.RetunToList();
        //            break;
        //    }
        //}

        public ICommand Add => new SaveDeveloperCommand(this);

        public ICommand UploadPhoto => new UploadPhoto(this);

        public ICommand UploadCv => new UploadCv(this);

        public ICommand ListviewSelectedChange => new ListviewSelectionChangedCommand(this);

        public ICommand ComboboxSelectedChange => new ComboboxSelectionChangedCommand(this);

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
                //if(string.IsNullOrEmpty(_selectedlangauge?.Name) == false)
                //{
                //    _alladdedlangauge.Add(_selectedlangauge);
                //    _alllangauge.Remove(_selectedlangauge);
                //}
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
                //if (string.IsNullOrEmpty(_selectedaddedlangauge?.Name)==false)
                //{
                //    _alladdedlangauge.Remove(_selectedaddedlangauge);
                //    _alllangauge.Add(_selectedaddedlangauge);
                //}
                OnPropertyChanged(nameof(SelectedAddedProgrammingLanguage));
            }
        }


        #endregion

        #region private
        /*public void AddToSelected()
        {
            if(string.IsNullOrEmpty(_selectedlangauge?.Name) == false)
            {
                _alladdedlangauge.Add(_selectedlangauge);
                _alllangauge.Remove(_selectedlangauge);
            }
        }

        public void RetunToList()
        {
            if (string.IsNullOrEmpty(_selectedaddedlangauge?.Name) == false)
            {
                _alladdedlangauge.Remove(_selectedaddedlangauge);
                _alllangauge.Add(_selectedaddedlangauge);
            }
        }*/
        #endregion
    }
}
