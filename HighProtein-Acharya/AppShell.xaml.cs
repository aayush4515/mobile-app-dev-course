namespace HighProtein_Acharya;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("RecipeDetailsPage", typeof(Pages.RecipeDetailsPage));
	}
}

