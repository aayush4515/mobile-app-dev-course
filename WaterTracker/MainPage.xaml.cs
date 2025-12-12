namespace WaterTracker;

public partial class MainPage : ContentPage
{
    private int glassesDrank = 0;
    private Border[] glassBorders;


	public MainPage()
	{
		InitializeComponent();

        // initialize the glasses border array
        glassBorders = new Border[]
        {
            Glass1, Glass2, Glass3, Glass4, Glass5, Glass6, Glass7, Glass8
        };

	}

    void OnAddWaterClicked(System.Object sender, System.EventArgs e)
    {
        if (glassesDrank < 8)
        {

            glassBorders[glassesDrank].BackgroundColor = Colors.LightBlue;
            glassesDrank++;

            UpdateStatus();
        }
        else
        {
            DisplayAlert("Comgrats!", "You've already had 8 glasses today!", "OK");
        }
    }

    void OnResetClicked(System.Object sender, System.EventArgs e)
    {
        foreach (var glass in glassBorders)
        {
            glass.BackgroundColor = Colors.White;
        }

        glassesDrank = 0;

        UpdateStatus();
    }

    private void UpdateStatus()
    {
        StatusLabel.Text = $"You've had {glassesDrank} glass{(glassesDrank == 1 ? "" : "es")} today.";
    }
}


