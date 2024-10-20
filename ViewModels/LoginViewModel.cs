using FinalProject.Models;
using FinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProject.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private async void OnLogin()
        {
            User user = UserServices.Instance.Login(Username, Password);
            // Implement your login logic here.
            // For example, check credentials using UserServices.
            if (user!=null && user.Id>0)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Login successful!", "OK");
                // Navigate to another page or perform actions after successful login.
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }
    }
}
