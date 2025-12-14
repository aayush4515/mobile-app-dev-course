using Cars_Acharya.ViewModels;

namespace Cars_Acharya.Views;

public partial class CarDetailPage : ContentPage
{
    public CarDetailPage(CarDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
