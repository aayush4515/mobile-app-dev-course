using HighProtein_Acharya.Models;
using HighProtein_Acharya.Services;
using static HighProtein_Acharya.App;
namespace HighProtein_Acharya.Pages;

public partial class LunchPage : ContentPage
{
    public WordPressPost? SelectedRecipe { get; set; }

    public LunchPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadPostDataAsync((int)RECIPES.LUNCH);
    }

    private async void OnTapped(System.Object sender, System.EventArgs e)
    {
        if (sender is Border border)
        {
            border.Stroke = Colors.LightGrey;

            if (sender is VisualElement { BindingContext: WordPressPost tappedItem })
            {
                SelectedRecipe = tappedItem;

                if (SelectedRecipe != null)
                {
                    string? url = SelectedRecipe.Link;

                    await Shell.Current.GoToAsync($"RecipeDetailsPage?url={url}");
                }
            }
        }
    }

    private async void LoadPostDataAsync(int Category)
    {
        RecipesCollectionView.IsVisible = false;

        try
        {
            BusyIndicator.IsRunning = true;
            BusyIndicator.IsVisible = true;

            var wp = new WordPressClient("https://wp.elmhurst.edu/highprotein");
            var posts = await wp.GetPostsByCategoryAsync(Category);

            // Sort
            posts.Sort((a, b) => string.Compare(a?.Title?.Rendered, b?.Title?.Rendered, StringComparison.OrdinalIgnoreCase));

            if (posts != null)
            {
                RecipesCollectionView.ItemsSource = posts;
                RecipesCollectionView.IsVisible = true;
                NoRecipes.IsVisible = false;
            }
            else
            {
                NoRecipes.Text = "There are no recipes to show in this view.";
                NoRecipes.IsVisible = true;
                RecipesCollectionView.IsVisible = false;
            }
        }
        catch (Exception ex)
        {
            NoRecipes.Text = ex.Message;
            NoRecipes.IsVisible = true;
            RecipesCollectionView.IsVisible = false;
        }
        finally
        {
            BusyIndicator.IsRunning = false;
            BusyIndicator.IsVisible = false;
        }

    }

    private async void OnHomeClicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

}