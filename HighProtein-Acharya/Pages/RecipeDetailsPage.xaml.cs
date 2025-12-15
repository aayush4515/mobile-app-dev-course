namespace HighProtein_Acharya.Pages;

public partial class RecipeDetailsPage : ContentPage, IQueryAttributable
{

    public string? URL { get; set; }

	public RecipeDetailsPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("url", out var urlObj) && urlObj is string url)
        {
            URL = url;
        }

        BindingContext = this;
    }

    async void OnShareClicked(System.Object sender, System.EventArgs e)
    {
        await DisplayAlert("ToDo", "Share Feature", "OK");
    }

    async void OnFavoriteClicked(System.Object sender, System.EventArgs e)
    {
        await DisplayAlert("ToDo", "Favorite Feature", "OK");
    }

    async void OnHomeClicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    void OnNavigating(System.Object sender, Microsoft.Maui.Controls.WebNavigatingEventArgs e)
    {
        BusyIndicator.IsRunning = true;
        BusyIndicator.IsVisible = true;

        RecipeWebView.IsVisible = false;
    }

    void OnNavigated(System.Object sender, Microsoft.Maui.Controls.WebNavigatedEventArgs e)
    {
        BusyIndicator.IsRunning = false;
        BusyIndicator.IsVisible = false;

        RecipeWebView.IsVisible = true;
    }
}
