using WeatherApp.Services;
namespace WeatherApp;

public partial class MainPage : ContentPage
{

	private readonly WeatherService _weatherService;

	public MainPage()
	{
		InitializeComponent();
		_weatherService = new WeatherService();
	}

    async void OnGetWeatherClicked(System.Object sender, System.EventArgs e)
    {
		string ZipCode = ZipCodeEntry.Text;

		if (string.IsNullOrEmpty(ZipCode))
		{
			await DisplayAlert("Error", "Please enter a valid zip code.", "OK");
			return;
		}

		try
		{
			var weatherData = await _weatherService.GetWeatherByZipCode(ZipCode);

			if (weatherData != null)
			{
				WeatherInfoLabel.Text = $"Weather in {weatherData.Name}: \n" +
					$"Temp: {Convert.ToInt32(weatherData.Main.Temp)} F \n" +
					$"Humidity: {weatherData.Main.Humidity} % \n" +
					$"Condition: {weatherData.Weather[0].Description}";
			}
			else
			{
				WeatherInfoLabel.Text = "Weather data not found.";
			}
		}
		catch (Exception ex)
		{
            WeatherInfoLabel.Text = $"Error: {ex.Message}";
        }
    }
}


