using Aletschhorn.DigitalEstateApp.ViewModels;

namespace Aletschhorn.DigitalEstateApp;

public partial class LoadingPage : ContentPage
{
    public LoadingPage(LoadingPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}