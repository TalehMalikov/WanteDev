using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.Commands.DeveloperCommands.LanguageCommands
{
    public class ComboboxSelectionChangedCommand : BaseCommand
    {
        private readonly DeveloperRegistrationWindowViewModel _viewModel;
        public ComboboxSelectionChangedCommand(DeveloperRegistrationWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(string.IsNullOrEmpty(_viewModel.SelectedProgrammingLanguage?.Name) == false)
            {
                _viewModel.AllAddedProgrammingLanguages.Add(_viewModel.SelectedProgrammingLanguage);
                _viewModel.AllProgrammingLanguages.Remove(_viewModel.SelectedProgrammingLanguage);
            }
        }
    }
}
