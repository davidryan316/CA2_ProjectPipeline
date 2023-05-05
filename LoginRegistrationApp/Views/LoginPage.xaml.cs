using LoginRegistrationApp.ViewModels;
using Microsoft.Maui.Controls;

namespace LoginRegistrationApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
