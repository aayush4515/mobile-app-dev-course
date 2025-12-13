namespace MoonShot_Acharya;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        // Register global routes for pages outside of the tabs
        Routing.RegisterRoute("Artemis1", typeof(Pages.Artemis1));
        Routing.RegisterRoute("Artemis2", typeof(Pages.Artemis2));
        Routing.RegisterRoute("Artemis3", typeof(Pages.Artemis3));
        Routing.RegisterRoute("Artemis4", typeof(Pages.Artemis4));
    }
}

