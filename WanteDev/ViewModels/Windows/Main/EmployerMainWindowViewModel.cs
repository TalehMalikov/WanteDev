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
using WanteDev.Commands.EmployerCommands;
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

        private EmployerModel currentEmployer;
        public EmployerModel CurrentEmployer
        {
            get
            {
                return currentEmployer;
            }
            set
            {
                currentEmployer = value;
                OnPropertyChanged(nameof(CurrentEmployer));
            }
        }


        public OpenEmployerMainWindowCommand OpenEmployerMainWindow => new OpenEmployerMainWindowCommand(this);

        public OpenEmployerProfileCommand OpenEmployerProfile => new OpenEmployerProfileCommand(this);

        public ICommand OpenDeveloperList => new OpenDeveloperListCommand(this);

        #region Properties
        public List<ProgrammingLanguageModel> AllProgrammingLanguages { get; set; }

        public List<ProgrammingLanguageModel> BackEnd => AllProgrammingLanguages.Where(p => p.Category.Name == "Backend").ToList();
        public List<ProgrammingLanguageModel> FrontEnd => AllProgrammingLanguages.Where(p => p.Category.Name == "FrontEnd").ToList();
        public List<ProgrammingLanguageModel> Cloud => AllProgrammingLanguages.Where(p => p.Category.Name == "Cloud").ToList();
        public List<ProgrammingLanguageModel> FullStack => AllProgrammingLanguages.Where(p => p.Category.Name == "FullStack").ToList();
        public List<ProgrammingLanguageModel> Cybersecurity => AllProgrammingLanguages.Where(p => p.Category.Name == "Cybersecurity").ToList();
        public List<ProgrammingLanguageModel> MobileDevelopment => AllProgrammingLanguages.Where(p => p.Category.Name == "Mobile Development").ToList();
        public List<ProgrammingLanguageModel> DBA => AllProgrammingLanguages.Where(p => p.Category.Name == "DBA").ToList();
        public List<ProgrammingLanguageModel> NetworkAdminstration => AllProgrammingLanguages.Where(p => p.Category.Name == "Network Adminstration").ToList();
        public List<ProgrammingLanguageModel> UXUI => AllProgrammingLanguages.Where(p => p.Category.Name == "UX/UI").ToList();
        public List<ProgrammingLanguageModel> MachineLearning => AllProgrammingLanguages.Where(p => p.Category.Name == "Machine Learning").ToList();
        public List<ProgrammingLanguageModel> DataScience => AllProgrammingLanguages.Where(p => p.Category.Name == "Data Science").ToList();
        public List<ProgrammingLanguageModel> GameDevelopment => AllProgrammingLanguages.Where(p => p.Category.Name == "Game Development").ToList();

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
