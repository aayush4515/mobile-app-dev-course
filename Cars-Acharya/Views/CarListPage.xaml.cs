using Cars_Acharya.Models;
using Cars_Acharya.ViewModels;

namespace Cars_Acharya.Views;

public partial class CarListPage : ContentPage
{
    private readonly CarListViewModel _vm;

    public CarListPage(CarListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadCommand.ExecuteAsync(null);
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Car car)
        {
            ((CollectionView)sender).SelectedItem = null;
            await _vm.OpenDetailsCommand.ExecuteAsync(car);
        }
    }
}
