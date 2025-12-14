using System.Collections.ObjectModel;
using Cars_Acharya.Models;
using Cars_Acharya.Services;
using CommunityToolkit.Mvvm.Input;

namespace Cars_Acharya.ViewModels;

public partial class CarListViewModel : BaseViewModel
{
    private readonly CarRepository _repo;

    public ObservableCollection<Car> Cars { get; } = new();

    public CarListViewModel(CarRepository repo)
    {
        _repo = repo;
        Title = "Car Listings";
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            Cars.Clear();
            var items = await _repo.GetCarsAsync();
            foreach (var c in items) Cars.Add(c);
        }
        finally { IsBusy = false; }
    }

    [RelayCommand]
    public async Task AddNewAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.CarDetailPage), new Dictionary<string, object>
        {
            { "Car", new Car { Year = DateTime.Now.Year, Make = "", Model = "", Price = 0 } }
        });
    }

    [RelayCommand]
    public async Task OpenDetailsAsync(Car? car)
    {
        if (car is null) return;
        await Shell.Current.GoToAsync(nameof(Views.CarDetailPage), new Dictionary<string, object>
        {
            { "Car", car }
        });
    }
}
