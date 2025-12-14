using System;
using System.Net.Http;
using Newtonsoft.Json;
namespace WeatherApp.Services
{
	public class WeatherService
	{
		private const string ApiKey = "f1706095baa0926b171fe022a88a6b3a";
		private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather?";

		private readonly HttpClient _httpClient;

		public WeatherService()
		{
			_httpClient = new HttpClient();
		}

		// makes the API call and retrieves the weather data
		public async Task<WeatherResponse> GetWeatherByZipCode(string ZipCode)
		{
			//var url = $"{BaseUrl}zip={ZipCode},us&appid={ApiKey}&units=imperial";
			var url = "https://api.openweathermap.org/data/2.5/weather?zip=60126,us&appid=f1706095baa0926b171fe022a88a6b3a&units=imperial";

            var response = await _httpClient.GetStringAsync(url);

			return JsonConvert.DeserializeObject<WeatherResponse>(response);
		}

	}

	public class WeatherResponse
	{
		public MainWeather Main { get; set; }
		public string Name { get; set; }
		public WeatherDescription[] Weather { get; set; }
	}

	public class MainWeather
	{
		public float Temp { get; set; }
		public float Humidity { get; set; }
	}

	public class WeatherDescription
	{
		public string Description { get; set; }
	}
}

