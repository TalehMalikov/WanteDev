using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.ViewModels.Windows.Main;

namespace WanteDev.Commands.Main
{
    public class OpenMainWindowCommand : BaseCommand
    {

        private readonly EmployerMainWindowViewModel _viewModel;
        public OpenMainWindowCommand(EmployerMainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
