using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Commands.ControlCommands.Profiles.Employer;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;

namespace WanteDev.ViewModels.Controls
{
    public class EmployerProfileControlViewModel : BaseControlViewModel<EmployerModel>
    {
        public EmployerProfileControlViewModel(IUnitOfWork db) : base(db)
        {
        }
        public SaveCommand Save => new SaveCommand(this);
    }
}
