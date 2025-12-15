namespace HighProtein_Acharya.Pages;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    async void OnHomeClicked(System.Object sender, System.EventArgs e)
    {
		await Shell.Current.GoToAsync("//MainPage");
    }
}
