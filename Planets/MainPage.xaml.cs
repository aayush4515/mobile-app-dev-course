namespace Planets;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}


    async void OnExploreNowClicked(System.Object sender, System.EventArgs e)
    {
		// Navigate to the planets page within the main/home tab
		await Shell.Current.GoToAsync("PlanetsPage");
    }

}


