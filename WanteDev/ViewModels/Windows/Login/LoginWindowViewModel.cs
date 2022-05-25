using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WanteDev.Commands.Auth;
using WanteDev.Commands.Auth.CommonAuthentication;
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
        private Visibility userNotFound = Visibility.Collapsed;

        public Visibility UserNotFound
        {
            get { return userNotFound; }
            set { userNotFound = value; OnPropertyChanged(nameof(UserControl)); }
        }

        private Visibility firstStackPanelVisibility = Visibility.Collapsed;

        public Visibility FirstStackPanelVisibility
        {
            get { return firstStackPanelVisibility; }
            set { firstStackPanelVisibility = value; OnPropertyChanged(nameof(FirstStackPanelVisibility)); }

        }
        private Visibility secondStackPanelVisibility = Visibility.Collapsed;
        public Visibility SecondStackPanelVisibility
        {
            get => secondStackPanelVisibility;
            set
            {
                secondStackPanelVisibility = value;
                OnPropertyChanged(nameof(SecondStackPanelVisibility));
            }
        }

        private Visibility thirdStackPanelVisibility = Visibility.Collapsed;

        public Visibility ThirdStackPanelVisibility
        {
            get { return thirdStackPanelVisibility; }
            set { thirdStackPanelVisibility = value; OnPropertyChanged(nameof(ThirdStackPanelVisibility)); }
        }

        private Visibility nullCodeVisibility = Visibility.Collapsed;

        public Visibility NullCodeVisibility
        {
            get { return nullCodeVisibility; }
            set
            {
                nullCodeVisibility = value;
                OnPropertyChanged(nameof(NullCodeVisibility));
            }
        }

        private Visibility incorectCodeVisibility = Visibility.Collapsed;

        public Visibility IncorrectCodeVisibility
        {
            get { return incorectCodeVisibility; }
            set { incorectCodeVisibility = value; OnPropertyChanged(nameof(IncorrectCodeVisibility)); }
        }
        private Visibility textInfoVisibility = Visibility.Collapsed;

        public Visibility TextInfoVisibility
        {
            get { return textInfoVisibility; }
            set
            {
                textInfoVisibility = value;
                OnPropertyChanged(nameof(TextInfoVisibility));
            }
        }


        private string userEnteredConfirmationCode;

        public string UserEnteredConfirmationCode
        {
            get { return userEnteredConfirmationCode; }
            set { userEnteredConfirmationCode = value; OnPropertyChanged(nameof(UserEnteredConfirmationCode)); }
        }


        private string confirmationCode;

        public string ConfirmationCode
        {
            get { return confirmationCode; }
            set { confirmationCode = value; }
        }



        private bool isChangeEnabled;

        public bool IsChangeEnabled
        {
            get { return isChangeEnabled; }
            set
            {
                isChangeEnabled = value;
                OnPropertyChanged(nameof(IsChangeEnabled));
            }
        }

        private string newPassword;

        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
                if (NewPassword == PasswordToConfirm)
                {
                    TextInfoVisibility = Visibility.Hidden;
                    IsChangeEnabled = true;
                }
                else
                {
                    IsChangeEnabled = false;
                    TextInfoVisibility = Visibility.Visible;
                }
            }
        }

        private string passwordToConfirm;
        public string PasswordToConfirm
        {
            get { return passwordToConfirm; }
            set
            {
                passwordToConfirm = value;
                if (NewPassword == PasswordToConfirm)
                {
                    TextInfoVisibility = Visibility.Hidden;
                    IsChangeEnabled = true;
                }
                else
                {
                    TextInfoVisibility = Visibility.Visible;
                    IsChangeEnabled = false;
                }
                OnPropertyChanged(nameof(PasswordToConfirm));
            }
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

        public ICommand VerifyConfirmationCode => new VerifyConfirmationCode(this);
        public ICommand ForgotPassword => new ForgotPassword(this);
        public SendConfirmationCode SendConfirmationCode => new(this);
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

        private string email;
        public string Email
        {
            get
            {
                return email;

            }
            set
            {
                email = value;
            }
        }

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
