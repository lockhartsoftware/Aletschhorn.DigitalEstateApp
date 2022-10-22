using Aletschhorn.DigitalEstateApp.Helpers;
using Aletschhorn.DigitalEstateApp.Models;
using Aletschhorn.DigitalEstateApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Aletschhorn.DigitalEstateApp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(CarApiService carApiService)
        {
            this.carApiService = carApiService;
        }

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        private CarApiService carApiService;

        [RelayCommand]
        async Task Login()
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayLoginMessage("Invalid Login Attempt");
            }
            else
            {
                // Call API to attempt a login.

                var loginModel = new LoginModel(username, password);

                var response = await carApiService.Login(loginModel);

                // Display message.
                await DisplayLoginMessage(carApiService.StatusMessage);

                if (!string.IsNullOrEmpty(response.Token))
                {
                    // Store token in secure storage
                    await SecureStorage.SetAsync("Token", response.Token);

                    // Build a menu on the fly...based on the user role
                    var jsonToken = new JwtSecurityTokenHandler().ReadToken(response.Token) as JwtSecurityToken;

                    var role = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(ClaimTypes.Role))?.Value;

                    App.UserInfo = new UserInfo()
                    {
                        Username = Username,
                        Role = role
                    };

                    // You can use Preferences.
                    //if (Preferences.ContainsKey(nameof(UserInfo)))
                    //{ Preferences.Remove(nameof(UserInfo)); }

                    // Navigate to app's main page.
                    MenuBuilder.BuildMenu();
                    await Shell.Current.GoToAsync($"{nameof(MainPage)}");

                }
                else
                {
                    await DisplayLoginMessage("Invalid Login Attempt");
                }
            }
        }

        async Task DisplayLoginMessage(string message)
        {
            await Shell.Current.DisplayAlert("Login Attempt Result", message, "OK");
            Password = string.Empty;
        }
    }
}
