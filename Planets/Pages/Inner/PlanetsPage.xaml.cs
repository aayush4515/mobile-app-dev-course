namespace Planets.Pages.Inner;

public partial class PlanetsPage : ContentPage
{
	public PlanetsPage()
	{
		InitializeComponent();
	}

    async void OnPlanetClicked(System.Object sender, System.EventArgs e)
    {

        if (sender is Button button && button.CommandParameter is string planet)
        {
            switch (planet)
            {
                case "Mercury":
                    await Shell.Current.GoToAsync("//InnerPlanetsPage/MercuryPage");
                    break;

                case "Venus":
                    await Shell.Current.GoToAsync("//InnerPlanetsPage/VenusPage");
                    break;

                case "Earth":
                    await Shell.Current.GoToAsync("//InnerPlanetsPage/EarthPage");
                    break;
                case "Mars":
                    await Shell.Current.GoToAsync("//InnerPlanetsPage/MarsPage");
                    break;
                default:
                    break;

            }
        }

    }
}
