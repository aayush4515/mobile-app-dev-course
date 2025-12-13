namespace MoonShot_Acharya.Pages;

public partial class MissionsPage : ContentPage
{
	public MissionsPage()
	{
		InitializeComponent();
	}

    async void OnArtemisClicked(System.Object sender, System.EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string missionType)
        {
            switch (missionType)
            {
                case "Artemis1":
                    await Shell.Current.GoToAsync("//MissionsPage/Artemis1");
                    break;

                case "Artemis2":
                    await Shell.Current.GoToAsync("//MissionsPage/Artemis2");
                    break;

                case "Artemis3":
                    await Shell.Current.GoToAsync("//MissionsPage/Artemis3");
                    break;

                case "Artemis4":
                    await Shell.Current.GoToAsync("//MissionsPage/Artemis4");
                    break;

                default:
                    break;
            }
        }
    }
}
