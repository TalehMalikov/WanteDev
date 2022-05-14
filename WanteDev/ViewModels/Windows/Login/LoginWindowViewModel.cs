using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WanteDev.Commands.Auth;
using WanteDev.Commands.Main;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Views.Windows.Login;

namespace WanteDev.ViewModels.Windows.Login
{
    public class LoginWindowViewModel : BaseWindowViewModel
    {
        public LoginWindowViewModel(LoginWindow loginWindow, IUnitOfWork db) : base(loginWindow, db)
        {
        }

        /*private string firstStepErrorMessage;
        public string FirstStepErrorMessage
        {
            get
            {
                return firstStepErrorMessage;
            }
            set
            {
                firstStepErrorMessage = value;
                OnPropertyChanged(nameof(FirstStepErrorMessage));
            }
        }

        private string confirmationCode;
        public string ConfirmationCode
        {
            get
            {
                return confirmationCode;
            }
            set
            {
                confirmationCode = value;
                OnPropertyChanged(nameof(ConfirmationCode));
            }
        }

        private string userEnteredConfirmationCode;
        public string UserEnteredConfirmationCode
        {
            get => userEnteredConfirmationCode;
            set
            {
                userEnteredConfirmationCode = value;
                OnPropertyChanged(nameof(UserEnteredConfirmationCode));
            }
        }*/

        //public string NewPassword { get; set; }
        //public string ConfirmNewPassword { get; set; }

        public LoginCommand SignIn => new LoginCommand(this);
        public RegistrationCommand SignUp => new RegistrationCommand(this);
        public Grid CenterGrid { get; set; }
        //public ForgotPassword ForgotPassword => new ForgotPassword(this);
        //public SendConfirmationCode SendConfirmationCode => new SendConfirmationCode(this);
        //public VerifyConfirmationCode VerifyConfirmationCode => new VerifyConfirmationCode(this);
        //public ResetPassword ResetPassword => new ResetPassword(this);

        /*private string secondStepErrorMessage;
        public string SecondStepErrorMessage
        {
            get
            {
                return secondStepErrorMessage;
            }
            set
            {
                secondStepErrorMessage = value;
                OnPropertyChanged(nameof(SecondStepErrorMessage));
            }
        }

        private Visibility secondStepErrorVisibility;
        public Visibility SecondStepErrorVisibility
        {
            get
            {
                return secondStepErrorVisibility;
            }
            set
            {
                secondStepErrorVisibility = value;
                OnPropertyChanged(nameof(SecondStepErrorVisibility));
            }
        }

        private Visibility resetThirdStepVisibility = Visibility.Collapsed;
        public Visibility ResetThirdStepVisibility
        {
            get
            {
                return resetThirdStepVisibility;
            }
            set
            {
                resetThirdStepVisibility = value;
                OnPropertyChanged(nameof(ResetThirdStepVisibility));
            }
        }

        private string thirdStepErrorMessage;
        public string ThirdStepErrorMessage
        {
            get
            {
                return thirdStepErrorMessage;
            }
            set
            {
                thirdStepErrorMessage = value;
                OnPropertyChanged(nameof(ThirdStepErrorMessage));
            }
        }

        private Visibility thirdStepErrorVisibility;
        public Visibility ThirdStepErrorVisibility
        {
            get
            {
                return thirdStepErrorVisibility;
            }
            set
            {
                thirdStepErrorVisibility = value;
                OnPropertyChanged(nameof(ThirdStepErrorVisibility));
            }
        }

        private Visibility resetSecondStepVisibility = Visibility.Collapsed;
        public Visibility ResetSecondStepVisibility
        {
            get
            {
                return resetSecondStepVisibility;
            }
            set
            {
                resetSecondStepVisibility = value;
                OnPropertyChanged(nameof(ResetSecondStepVisibility));
            }
        }

        private Visibility firstStepErrorVisibility = Visibility.Collapsed;
        public Visibility FirstStepErrorVisibility
        {
            get
            {
                return firstStepErrorVisibility;
            }
            set
            {
                firstStepErrorVisibility = value;
                OnPropertyChanged(nameof(FirstStepErrorVisibility));
            }
        }

        private Visibility resetFirstStepVisibility = Visibility.Collapsed;
        public Visibility ResetFirstStepVisibility
        {
            get
            {
                return resetFirstStepVisibility;
            }
            set
            {
                resetFirstStepVisibility = value;
                OnPropertyChanged(nameof(ResetFirstStepVisibility));
            }
        }*/

        public string Email { get; set; } = "talehmalik29@gmail.com";

        private Visibility loginWindowVisibility = Visibility.Visible;
        public Visibility LoginWindowVisibility
        {
            get
            {
                return loginWindowVisibility;
            }
            set
            {
                loginWindowVisibility = value;
                OnPropertyChanged(nameof(LoginWindowVisibility));
            }
        }





        private Visibility loginErrorVisibility = Visibility.Collapsed;
        public Visibility LoginErrorVisibility
        {
            get
            {
                return loginErrorVisibility;
            }
            set
            {
                loginErrorVisibility = value;
                OnPropertyChanged(nameof(LoginErrorVisibility));
            }
        }
    }
}
