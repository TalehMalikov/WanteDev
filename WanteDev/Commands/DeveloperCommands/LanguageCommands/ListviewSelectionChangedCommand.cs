using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.Commands.DeveloperCommands.LanguageCommands
{
    public class ListviewSelectionChangedCommand : BaseCommand
    {
        private readonly DeveloperRegistrationWindowViewModel _viewModel;
        public ListviewSelectionChangedCommand(DeveloperRegistrationWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (string.IsNullOrEmpty(_viewModel.SelectedAddedProgrammingLanguage?.Name) == false)
            {
                _viewModel.AllAddedProgrammingLanguages.Remove(_viewModel.SelectedAddedProgrammingLanguage);
                _viewModel.AllProgrammingLanguages.Add(_viewModel.SelectedAddedProgrammingLanguage);
            }
        }
    }
}
