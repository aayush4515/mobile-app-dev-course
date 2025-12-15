using System;
using System.Net.Http;
using Newtonsoft.Json;
using FilmFinder_Acharya.Models;

namespace FilmFinder_Acharya.Services
{
	public class FilmService
	{
        private const string ApiKey = "7bcbd8f4";
        private const string BaseUrl = "https://www.omdbapi.com/";

        private readonly HttpClient _httpClient = new();

        public FilmService()
        {
            _httpClient = new HttpClient();
        }

        // makes the API call and retrieves the film details using name and year
        public async Task<FilmSearchResponse> GetFilmsByNameAndYear(string name, string year)
        {
            var url = $"{BaseUrl}?apikey={ApiKey}&s={name}&y={year}";
            var response = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<FilmSearchResponse>(response);
        }

        public async Task<FilmDetails> GetFilmByImdbId(string imdbId)
        {
            var url = $"{BaseUrl}?apikey={ApiKey}&i={imdbId}&plot=full";
            var response = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<FilmDetails>(response);
        }
    }

    
}

