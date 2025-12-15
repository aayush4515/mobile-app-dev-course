using FilmFinder_Acharya.Models;
using FilmFinder_Acharya.Services;

namespace FilmFinder_Acharya;

public partial class FilmDetailsPage : ContentPage
{
    private readonly FilmService _filmService = new();

    public FilmDetailsPage(string imdbId)
    {
        InitializeComponent();
        LoadFilmDetails(imdbId);
    }

    private async void LoadFilmDetails(string imdbId)
    {
        var film = await _filmService.GetFilmByImdbId(imdbId);

        TitleLabel.Text = $"{film.Title} ({film.Year})";
        PlotLabel.Text = film.Plot;

        DirectorLabel.Text = $"Director: {film.Director}";
        WriterLabel.Text = $"Writer: {film.Writer}";
        ActorsLabel.Text = $"Stars: {film.Actors}";

        if (!string.IsNullOrEmpty(film.Poster) && film.Poster != "N/A")
        {
            PosterImage.Source = ImageSource.FromUri(new Uri(film.Poster));
        }
    }
}
