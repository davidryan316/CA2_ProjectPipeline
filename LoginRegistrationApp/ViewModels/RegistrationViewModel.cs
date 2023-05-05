using LoginRegistrationApp.Data;
using LoginRegistrationApp.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace LoginRegistrationApp.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private UserDataStore _userDataStore;
        private string _username;
        private string _email;
        private string _password;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand RegisterCommand { get; }

        public RegistrationViewModel()
        {
            _userDataStore = new UserDataStore();
            RegisterCommand = new RelayCommand(Register);
        }

        private async void Register()
        {
            // Add your validation rules here
            // ...

            if (IsBusy) return;

            IsBusy = true;
            User user = new User { Username = Username, Email = Email, Password = Password };
            bool isRegistered = await _userDataStore.RegisterUserAsync(user);
            IsBusy = false;

            if (isRegistered)
            {
                // Navigate back to the login page if successful
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                // Display an error message
                await Application.Current.MainPage.DisplayAlert("Error", "Registration failed", "OK");
            }
        }
    }
}

//using LoginRegistrationApp.Data;
//using Microsoft.Toolkit.Mvvm.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace LoginRegistrationApp.ViewModels
//{
//    private UserDataStore _userDataStore;

//    public class RegistrationViewModel : BaseViewModel
//    {
//        private string _username;
//        private string _email;
//        private string _password;
//        private ICommand _registerCommand;
//        _userDataStore = new UserDataStore();

//        public string Username
//        {
//            get => _username;
//            set => SetProperty(ref _username, value);
//        }

//        public string Email
//        {
//            get => _email;
//            set => SetProperty(ref _email, value);
//        }

//        public string Password
//        {
//            get => _password;
//            set => SetProperty(ref _password, value);
//        }

//        public ICommand RegisterCommand => _registerCommand ??= new RelayCommand(Register, CanRegister);

//        private bool CanRegister() => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);

//        private async void Register()
//        {
//            IsBusy = true;
//            var user = new User { Username = Username, Email = Email, Password = Password };
//            bool isRegistered = await _userDataStore.RegisterUserAsync(user);
//            IsBusy = false;

//            if (isRegistered)
//            {
//                // Navigate back to the login page if successful
//                await Application.Current.MainPage.Navigation.PopAsync();
//            }
//            else
//            {
//                // Display an error message
//                await Application.Current.MainPage.DisplayAlert("Error", "Registration failed", "OK");
//            }
//        }
//    }

//}
