using Aletschhorn.DigitalEstateApp.Models;
using Aletschhorn.DigitalEstateApp.Services;

namespace Aletschhorn.DigitalEstateApp;

public partial class App : Application
{
    public static UserInfo UserInfo;

    public static CarDatabaseService CarDatabaseService { get; private set; }
    public App(CarDatabaseService carDatabaseService)
	{
		InitializeComponent();

		MainPage = new AppShell();
        CarDatabaseService = carDatabaseService;
    }
}
