using Aletschhorn.DigitalEstateApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aletschhorn.DigitalEstateApp
{
    public class LogoutPage : ContentPage
    {
        public LogoutPage(LogoutViewModel logoutViewModel)
        {
            Content = new VerticalStackLayout
            {
                Children = {
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Logging Out"
                }
            }
            };

            BindingContext = logoutViewModel;
        }
    }
}
