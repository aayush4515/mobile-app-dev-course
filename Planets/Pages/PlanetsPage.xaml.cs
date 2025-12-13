namespace Planets.Pages;

public partial class PlanetsPage : ContentPage
{
	public PlanetsPage()
	{
		InitializeComponent();

		// Hide the back button from the UI
		Shell.SetBackButtonBehavior(this, new BackButtonBehavior
		{
			IsVisible = false
		}) ;
	}

    protected override bool OnBackButtonPressed()
    {
		// Return true to cancel the default back button behavior
		return true;
    }


}
