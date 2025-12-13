namespace Planets;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// Register global routes for pages outside of the tabs
		Routing.RegisterRoute("PlanetsPage", typeof(Pages.PlanetsPage));

		Routing.RegisterRoute("MercuryPage", typeof(Pages.Inner.MercuryPage));
        Routing.RegisterRoute("VenusPage", typeof(Pages.Inner.VenusPage));
        Routing.RegisterRoute("EarthPage", typeof(Pages.Inner.EarthPage));
        Routing.RegisterRoute("MarsPage", typeof(Pages.Inner.MarsPage));

    }
	
}

