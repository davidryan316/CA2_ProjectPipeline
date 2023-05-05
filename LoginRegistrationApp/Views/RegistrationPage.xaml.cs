using LoginRegistrationApp.ViewModels;
using Microsoft.Maui.Controls;

namespace LoginRegistrationApp.Views
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = new RegistrationViewModel();
        }
    }
}
