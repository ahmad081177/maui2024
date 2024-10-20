using FinalProject.Models;
using FinalProject.Services;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace FinalProject.ViewModels
{
    class RegisterViewModel : ViewModelBase
    {
        User user;
        private string username;
        private string password;
        private string email;
        private string phone;
        private string firstName;
        private string lastName;
        private DateTime birthdate = DateTime.Now.AddYears(-18);
        private bool isAdmin = false;
        private string errorMessage = "";
        public string UsernameErrorLabel { get; set; } = "";
        public string PasswordErrorLable { get; set; } = "";
        public string EmailErrorLable { get; set; } = "";
        public string PhoneErrorLable { get; set; } = "";
        public string FirstNameErrorLable { get; set; } = "";
        public string LastNameErrorLable { get; set; } = "";
        //public string BirthdateErrorLable { get; set; } = "";
        //public string IsAdminErrorLable { get; set; } = "";
        public string ErrorMessageErrorLabel { get; set; } = "";
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged(nameof(Username));
                    HandleError();
                }
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                    HandleError();
                }
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                    HandleError();
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                    HandleError();
                }
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                if (phone!= value)
                {
                    phone= value;
                    OnPropertyChanged(nameof(Phone));
                    HandleError();
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password= value;
                    OnPropertyChanged(nameof(Password));
                    HandleError();
                }
            }
        }
        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                if (birthdate != value)
                {
                    birthdate = value;
                    OnPropertyChanged(nameof(Birthdate));
                    HandleError();
                }
            }
        }
        public bool IsAdmin
        {
            get { return isAdmin; }
            set
            {
                if (isAdmin != value)
                {
                    isAdmin = value;
                    OnPropertyChanged(nameof(IsAdmin));
                    HandleError();
                }
            }
        }
        public int CalculatedAge
        {
            get
            {
                return DateTime.Now.Year - Birthdate.Year;
            }
        }

        //PROPERTY to be Bound to the Button Command
        public ICommand RegisterCommand
        {
            get; private set;
        }
        public RegisterViewModel()
        {
            RegisterCommand = new Command(Register);
        }
        private async void Register()
        {
            user = new User() { 
                Username = Username, 
                Password = Password, 
                Email = Email, 
                Phone = Phone, 
                FirstName = FirstName, 
                LastName = LastName, 
                Birthdate = Birthdate, 
                IsAdmin = IsAdmin 
            };
            bool r = UserServices.Instance.Register(user);
            if (!r)
            {
                ErrorMessage = "Username already exists";
                OnPropertyChanged(nameof(HasError));
                return;
            }
            //Switch to the Login Page
            await Application.Current.MainPage.Navigation.PushAsync(new Views.Auth.LoginPage());
        }

        public bool CanRegister
        {
            get
            {
                return !HasError;
            }
        }
        public bool HasError
        {
            get
            {
                return !string.IsNullOrEmpty(errorMessage);
            }

        }
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }
        private void HandleError()
        {
            ErrorMessage = "";
            UsernameErrorLabel = "";
            EmailErrorLable = "";
            PhoneErrorLable = "";
            FirstNameErrorLable = "";
            LastNameErrorLable = "";
            PasswordErrorLable = "";
            if (!IsValidName())
            {
                UsernameErrorLabel="Username is either short or includes invalid chars";
            }
            if (!IsValidEmail())
            {
                EmailErrorLable= "Email is not valid";
            }
            if (string.IsNullOrEmpty(FirstName))
            {
                FirstNameErrorLable= "First Name is required";
            }
            if (string.IsNullOrEmpty(LastName))
            {
                LastNameErrorLable= "Last Name is required";
            }
            if (string.IsNullOrEmpty(Phone))
            {
                PhoneErrorLable= "Phone is required";
            }
            if (!IsValidPassword())
            {
                PasswordErrorLable = "Password should be at least 8 chars with digit, lower char, uppercase char and special char";
            }

            OnPropertyChanged(nameof(UsernameErrorLabel));
            OnPropertyChanged(nameof(EmailErrorLable));
            OnPropertyChanged(nameof(FirstNameErrorLable));
            OnPropertyChanged(nameof(LastNameErrorLable));
            OnPropertyChanged(nameof(PhoneErrorLable));
            OnPropertyChanged(nameof(PasswordErrorLable));
            OnPropertyChanged(nameof(HasError));
            OnPropertyChanged(nameof(CanRegister));
        }
        private bool IsValidName()
        {
            if (string.IsNullOrEmpty(Username))
            {
                return false;
            }
            Regex reg = new Regex(@"^[a-zA-Z][a-zA-Z0-9]{2,}$");
            return reg.IsMatch(Username);
        }
        private bool IsValidEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                return false;
            }
            //Check if email is valid
            Regex reg = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return reg.IsMatch(Email);
        }
        private bool IsValidPassword()
        {
            if (string.IsNullOrEmpty(Password))
            {
                return false;
            }
            //Password should be at least 8 characters long includes at least one uppercase letter, one lowercase letter, one number, and one special character
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(Password);
        }
    }
}
