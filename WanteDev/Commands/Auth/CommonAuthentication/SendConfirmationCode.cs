using EmailSending;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanteDev.ViewModels.Windows.Login;

namespace WanteDev.Commands.Auth.CommonAuthentication
{
    public class SendConfirmationCode : BaseCommand
    {
        private readonly LoginWindowViewModel viewModel;
        public SendConfirmationCode(LoginWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var maybeDeveloper = viewModel.DB.DeveloperRepository.Get(viewModel.Email);
            var maybeEmployer = viewModel.DB.EmployerRepository.Get(viewModel.Email);
            var maybeAdmin = viewModel.DB.AdminRepository.Get(viewModel.Email);
            if (maybeAdmin is null && maybeDeveloper is null && maybeEmployer is null)
            {
                viewModel.UserNotFound = Visibility.Visible;
            }
            else
            {
                TrySend();
                viewModel.LoginWindowVisibility = Visibility.Collapsed;
                viewModel.FirstStackPanelVisibility = Visibility.Collapsed;
                viewModel.SecondStackPanelVisibility = Visibility.Visible;

            }


        }
        private void TrySend()
        {
            try
            {
                YahooClientInfo client = new YahooClientInfo() { UserEmail = "eserviceapp@yahoo.com", UserPassword = "rbftytbmsifttztt" };

                YahooEmailSender emailSender = new YahooEmailSender(client);
                viewModel.ConfirmationCode = new Random().Next(100000, 999999).ToString();
                bool result = emailSender.SendEmail(new EmailMessage()
                {
                    TO = new List<string>() { viewModel.Email },
                    IsBodyHtml = false,
                    Body = viewModel.ConfirmationCode,
                    Subject = "Your Confirmation Code is Below :"
                }).IsMessageDelivered;
                if (!result)
                {
                    viewModel.LoginErrorVisibility = Visibility.Visible;
                }
            }
            catch
            {
                viewModel.LoginErrorVisibility = Visibility.Visible;
            }
        }
    }
}
