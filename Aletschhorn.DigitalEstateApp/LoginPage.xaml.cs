using Aletschhorn.DigitalEstateApp.ViewModels;

namespace Aletschhorn.DigitalEstateApp;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        BindingContext = loginViewModel;
    }
}