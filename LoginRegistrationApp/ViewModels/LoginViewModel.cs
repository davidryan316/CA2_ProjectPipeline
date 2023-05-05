using LoginRegistrationApp.Data;
using LoginRegistrationApp.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using LoginRegistrationApp.Views;

namespace LoginRegistrationApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private UserDataStore _userDataStore;
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegistrationCommand { get; }

        public LoginViewModel()
        {
            _userDataStore = new UserDataStore();
            LoginCommand = new RelayCommand(Login);
            NavigateToRegistrationCommand = new Command(NavigateToRegistration);
        }
        private async void NavigateToRegistration()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
        }

        private async void Login()
        {
            if (IsBusy) return;

            IsBusy = true;
            User user = await _userDataStore.GetUserByUsernameAndPasswordAsync(Username, Password);
            IsBusy = false;

            if (user != null)
            {
                // Navigate to the main page if successful
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                // Display an error message
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid credentials", "OK");
            }

        }
    }
}



//using Microsoft.Toolkit.Mvvm.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace LoginRegistrationApp.ViewModels
//{
//    public class LoginViewModel : BaseViewModel
//    {
//        private string _username;
//        private string _password;
//        private ICommand _loginCommand;
//        private ICommand _navigateToRegistrationCommand;

//        public string Username
//        {
//            get => _username;
//            set => SetProperty(ref _username, value);
//        }

//        public string Password
//        {
//            get => _password;
//            set => SetProperty(ref _password, value);
//        }

//        public ICommand LoginCommand => _loginCommand ??= new RelayCommand(Login, CanLogin);
//        public ICommand NavigateToRegistrationCommand => _navigateToRegistrationCommand ??= new RelayCommand(NavigateToRegistration);

//        private bool CanLogin() => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

//        private async void Login()
//        {
//            IsBusy = true;
//            var user = await _userDataStore.GetUserByUsernameAndPasswordAsync(Username, Password);
//            IsBusy = false;

//            if (user != null)
//            {
//                // Navigate to the main page if successful
//                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
//            }
//            else
//            {
//                // Display an error message
//                await Application.Current.MainPage.DisplayAlert("Error", "Invalid credentials", "OK");
//            }
//        }

//            private async void NavigateToRegistration()
//        {
//            // Navigate to the Registration page
//        }
//    }

//}
