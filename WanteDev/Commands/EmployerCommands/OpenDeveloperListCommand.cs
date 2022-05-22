﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WanteDev.Models;
using WanteDev.ViewModels.Windows.Main;

namespace WanteDev.Commands.EmployerCommands
{
    public class OpenDeveloperListCommand : BaseCommand
    {
        private readonly EmployerMainWindowViewModel _viewmodel;
        public OpenDeveloperListCommand(EmployerMainWindowViewModel viewModel)
        {
            _viewmodel = viewModel; 
        }


        public override void Execute(object parameter)
        {
            string? name2 = _viewmodel.SearchedProgrammingLanguage.Name;
        }
    }
}