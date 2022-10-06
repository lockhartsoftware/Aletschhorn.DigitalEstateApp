using Aletschhorn.DigitalEstateApp.ViewModels;

namespace Aletschhorn.DigitalEstateApp;

public partial class MainPage : ContentPage
{
	public MainPage(CarListViewModel carListViewModel)
	{
		InitializeComponent();
        BindingContext = carListViewModel;
    }
}