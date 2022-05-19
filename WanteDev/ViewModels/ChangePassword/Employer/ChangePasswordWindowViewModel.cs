using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WanteDev.Commands.Auth.ProfilesChangePassword.Employer;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;
using WanteDev.ViewModels.Controls;

namespace WanteDev.ViewModels.ChangePassword.Employer
{
    public class ChangePasswordWindowViewModel : BaseWindowViewModel, INotifyPropertyChanged
    {

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
        private string userEnteredPreviousPassword;



        public string UserEnteredPreviousPassword
        {
            get { return userEnteredPreviousPassword; }
            set
            {
                userEnteredPreviousPassword = value;
                OnPropertyChanged(nameof(UserEnteredPreviousPassword));
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

        private EmployerModel employer;
        public EmployerModel Employer
        {
            get
            {
                return employer;
            }
            set
            {
                this.employer = value;
                OnPropertyChanged(nameof(Employer));
            }
        }
        public ICommand Next => new Next(this);

        public ICommand SaveChangedPassword => new SaveChangedPassword(this);

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
        private Visibility firstStackPanelVisibility = Visibility.Visible;

        public Visibility FirstStackPanelVisibility
        {
            get { return firstStackPanelVisibility; }
            set
            {
                firstStackPanelVisibility = value;
                OnPropertyChanged(nameof(FirstStackPanelVisibility));
            }
        }

        private Visibility secondStackPanelVisibility = Visibility.Hidden;

        public Visibility SecondStackPanelVisibility
        {
            get { return secondStackPanelVisibility; }
            set
            {
                secondStackPanelVisibility = value;
                OnPropertyChanged(nameof(SecondStackPanelVisibility));
            }
        }


        public ChangePasswordWindowViewModel(Window window, IUnitOfWork db, EmployerProfileControlViewModel viewModel) : base(window, db)
        {
            Employer = viewModel.CurrentValue;
        }
    }
}
