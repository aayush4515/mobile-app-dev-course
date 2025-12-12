using System.Collections.ObjectModel;
using System.Text.Json;
namespace GroceryToDo;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<Item> items = new ObservableCollection<Item>();

	public MainPage()
	{
		InitializeComponent();

        if (Preferences.ContainsKey("grocery_list"))
        {
            items = LoadItems();
        }
        ItemCollectionView.ItemsSource = items;
    }

    private static ObservableCollection<Item> LoadItems()
    {
        string json = Preferences.Get("grocery_list", "[]");
        var list = JsonSerializer.Deserialize<List<Item>>(json);

        return new ObservableCollection<Item>(list ?? new List<Item>());
    }

    private void SaveItems()
    {
        // save the item in JSON in a list within the Preferences
        string json = JsonSerializer.Serialize(items);
        Preferences.Set("grocery_list", json);

        ItemEntry.Text = string.Empty;
    }

    void OnAddToListClicked(System.Object sender, System.EventArgs e)
    {
        // save the item to Preferences
        string itemName = ItemEntry.Text;

        if (!string.IsNullOrEmpty(itemName))
        {
            items.Add(new Item { name = itemName, IsGotten = false });
        }

        SaveItems();
    }

    void OnItemStatusChanged(System.Object sender, Microsoft.Maui.Controls.ToggledEventArgs e)
    {
        var toggle = (Switch)sender;
        var item = (Item)toggle.BindingContext;
        item.IsGotten = e.Value;

        SaveItems();
    }

    private async void OnDeleteTapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (sender is not Image image)
        {
            return;
        }

        if (image.BindingContext is not Item item)
        {
            return;
        }

        if (item == null)
        {
            return;
        }

        bool confirm = await DisplayAlert("Delete Item?", $"Delete {item.name}?", "Yes", "No");

        if (confirm)
        {
            items.Remove(item);
            SaveItems();
        }

    }
        
}


