using Aletschhorn.DigitalEstateApp.Views;

namespace Aletschhorn.DigitalEstateApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(CarDetailsPage), typeof(CarDetailsPage));

    }
}
