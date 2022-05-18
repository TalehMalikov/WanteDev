using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WanteDev.Commands.Auth;
using WanteDev.Commands.Main;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.ViewModels.Windows.Main
{
    public class EmployerMainWindowViewModel : BaseWindowViewModel
    {
        public EmployerMainWindowViewModel(Window window, IUnitOfWork db) : base(window, db)
        {
        }
        // example : OpenPrivateInformationCommand
        public EmployerModel CurrentEmployer { get; set; }

        public OpenEmployerMainWindowCommand OpenEmployerMainWindow => new OpenEmployerMainWindowCommand(this);

        public OpenEmployerProfileCommand OpenEmployerProfile => new OpenEmployerProfileCommand(this);
        public Grid CenterGrid { get; set; }

        #region Properties
        public  List<ProgrammingLanguageModel> AllProgrammingLanguages { get; set; }

        public List<ProgrammingLanguageModel> BackEnd => (List<ProgrammingLanguageModel>)AllProgrammingLanguages.Select(p => p.Category.Name == "Backend" );


        private ProgrammingLanguageModel _selectedLanguage;

        public ProgrammingLanguageModel SelectedProgrammingLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(nameof(_selectedLanguage));
            }
        }





        private ObservableCollection<DeveloperModel> allDevelopers;

        public ObservableCollection<DeveloperModel> AllDevelopers
        {
            get 
            { 
                return allDevelopers; 
            }

            set 
            {
                allDevelopers = value;
            }
        }
        #endregion

    }
}
