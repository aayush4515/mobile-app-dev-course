using System.Collections.ObjectModel;
using FilmFinder_Acharya.Models;
using FilmFinder_Acharya.Services;

namespace FilmFinder_Acharya;

public partial class MainPage : ContentPage
{
    private readonly FilmService _filmService = new();

    public ObservableCollection<Film> Films { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    async void OnSearchClicked(object sender, EventArgs e)
    {
        Films.Clear();

        var title = FilmNameEntry.Text;
        var year = FilmYearEntry.Text;

        if (string.IsNullOrWhiteSpace(title))
        {
            await DisplayAlert("Error", "Please enter a film name.", "OK");
            return;
        }

        var result = await _filmService.GetFilmsByNameAndYear(title, year);

        if (result?.Search != null)
        {
            foreach (var film in result.Search)
            {
                Films.Add(film);
            }
        }
        else
        {
            await DisplayAlert("No Results", "No films found.", "OK");
        }
    }

    async void OnFilmSelected(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var selectedFilm = e.CurrentSelection.FirstOrDefault() as Film;

        if (selectedFilm == null)
            return;

        await Navigation.PushAsync(new FilmDetailsPage(selectedFilm.imdbID));

        ((CollectionView)sender).SelectedItem = null;
    }
}
