using Cars_Acharya.Views;

namespace Cars_Acharya;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(CarDetailPage), typeof(CarDetailPage));
    }
}

