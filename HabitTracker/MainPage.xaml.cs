using System.Text.Json;
namespace HabitTracker;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();

        if (Preferences.ContainsKey("habit"))
        {
            GetHAbit();
            ShowTracking(true);
        }
	}

    private void ShowTracking(bool display)
    {
        if (display)
        {
            // show the tracking options
            HabitEntry.IsVisible = false;
            TrackHabitButton.IsVisible = false;

            HabitLabel.IsVisible = true;
            ButtonGrid.IsVisible = true;
            HabitTrackingGrid.IsVisible = true;
        }
        else
        {
            HabitEntry.IsVisible = true;
            TrackHabitButton.IsVisible = true;

            HabitLabel.IsVisible = false;
            ButtonGrid.IsVisible = false;
            HabitTrackingGrid.IsVisible = false;

            HabitEntry.Text = string.Empty;
            HabitLabel.Text = string.Empty;
        }
    }

    private void SaveHabit()
    {
        Habit habit = new Habit
        {
            Name = HabitLabel.Text,
            Sunday = SundaySwitch.IsToggled,
            Monday = MondaySwitch.IsToggled,
            Tuesday = TuesdaySwitch.IsToggled,
            Wednesday = WednesdaySwitch.IsToggled,
            Thursday = ThursdaySwitch.IsToggled,
            Friday = FridaySwitch.IsToggled,
            Saturday = SaturdaySwitch.IsToggled
        };

        // serialize the object to a JSON string
        string json = JsonSerializer.Serialize(habit);

        // save the habit to the Preference
        Preferences.Set("habit", json);
    }

    private void GetHAbit()
    {
        string json = Preferences.Get("habit", "[]");

        // deserialize the JSON string back to a Habit object
        var habit = JsonSerializer.Deserialize<Habit>(json);

        if (habit is not null)
        {
            HabitLabel.Text = habit.Name;
            SundaySwitch.IsToggled = habit.Sunday;
            MondaySwitch.IsToggled = habit.Monday;
            TuesdaySwitch.IsToggled = habit.Tuesday;
            WednesdaySwitch.IsToggled = habit.Wednesday;
            ThursdaySwitch.IsToggled = habit.Thursday;
            FridaySwitch.IsToggled = habit.Friday;
            SaturdaySwitch.IsToggled = habit.Saturday;

        }
    }

    void SaveHabit(System.Object sender, Microsoft.Maui.Controls.ToggledEventArgs e)
    {
        SaveHabit();
    }

    void OnTrackHabitButtonClicked(System.Object sender, System.EventArgs e)
    {
        if (!string.IsNullOrEmpty(HabitEntry.Text))
        {
            HabitLabel.Text = HabitEntry.Text;

            SaveHabit();
            ShowTracking(true);
        }
    }

    private void ResetTracking()
    {
        SundaySwitch.IsToggled = false;
        MondaySwitch.IsToggled = false;
        TuesdaySwitch.IsToggled = false;
        WednesdaySwitch.IsToggled = false;
        ThursdaySwitch.IsToggled = false;
        FridaySwitch.IsToggled = false;
        SaturdaySwitch.IsToggled = false;
    }

    void OnResetButtonClicked(System.Object sender, System.EventArgs e)
    {
        ResetTracking();
    }

    void OnClearButtonClicked(System.Object sender, System.EventArgs e)
    {
        ShowTracking(false);
        ResetTracking();

        Preferences.Remove("habit");
    }

    
}


