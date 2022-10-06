using Aletschhorn.DigitalEstateApp.Services;

namespace Aletschhorn.DigitalEstateApp;

public partial class App : Application
{
	public static CarService CarService { get; private set; }
	public App(CarService carService)
	{
		InitializeComponent();

		MainPage = new AppShell();
		CarService = carService;
    }
}
