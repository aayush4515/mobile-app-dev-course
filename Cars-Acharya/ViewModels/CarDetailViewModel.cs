using Cars_Acharya.Models;
using Cars_Acharya.Services;
using CommunityToolkit.Mvvm.Input;

namespace Cars_Acharya.ViewModels;

[QueryProperty(nameof(Car), "Car")]
public partial class CarDetailViewModel : BaseViewModel
{
    private readonly CarRepository _repo;

    public CarDetailViewModel(CarRepository repo)
    {
        _repo = repo;
        Title = "Car Details";
    }

    private Car? car;
    public Car? Car
    {
        get => car;
        set => SetProperty(ref car, value);
    }

    [RelayCommand]
    public async Task SaveAsync()
{
    if (Car is null)
        return;

    // --- VALIDATION (Stretch Challenge) ---
    if (string.IsNullOrWhiteSpace(Car.Make))
    {
        await App.Current.MainPage.DisplayAlert(
            "Validation Error",
            "Make is required.",
            "OK");
        return;
    }

    if (string.IsNullOrWhiteSpace(Car.Model))
    {
        await App.Current.MainPage.DisplayAlert(
            "Validation Error",
            "Model is required.",
            "OK");
        return;
    }

    int currentYear = DateTime.Now.Year + 1;
    if (Car.Year < 1886 || Car.Year > currentYear)
    {
        await App.Current.MainPage.DisplayAlert(
            "Validation Error",
            $"Year must be between 1886 and {currentYear}.",
            "OK");
        return;
    }
    // --- END VALIDATION ---

    await _repo.SaveCarAsync(Car);
    await Shell.Current.GoToAsync("..");
}

    [RelayCommand]
    public async Task DeleteAsync()
    {
        if (Car is null || Car.Id == 0) return;
        var confirm = await App.Current.MainPage.DisplayAlert("Delete", "Delete this car?", "Yes", "No");
        if (!confirm) return;
        await _repo.DeleteCarAsync(Car);
        await Shell.Current.GoToAsync("..");
    }
}
