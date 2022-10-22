using Aletschhorn.DigitalEstateApp.ViewModels;

namespace Aletschhorn.DigitalEstateApp.Views;

public partial class CarDetailsPage : ContentPage
{
    private readonly CarDetailsViewModel carDetailsViewModel;

    public CarDetailsPage(CarDetailsViewModel carDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = carDetailsViewModel;
        this.carDetailsViewModel = carDetailsViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await carDetailsViewModel.GetCarData();
    }
}