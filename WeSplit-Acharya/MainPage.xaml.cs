namespace WeSplit_Acharya;

public partial class MainPage : ContentPage
{

    double totalAmount = 0.00;
    double tipPercentage = 0.00;
    int numPeople = 0;
    double eachPersonPays = 0.00;

	public MainPage()
	{
		InitializeComponent();
	}

    void OnNumberOfPeopleChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {

        // user pressed "+"
        if (e.NewValue > e.OldValue)
        {
            numPeople++;
        }
        // user pressed "-"
        else if (e.NewValue < e.OldValue)
        {
            numPeople--;
        }

        // display the number of people selected
        NumberOfPeopleSelected.Text = $"{numPeople} person";
    }

    void OnCalculateTipClicked(System.Object sender, System.EventArgs e)
    {
        // some null-value checks
        if (!double.TryParse(CheckAmount.Text, out totalAmount))
        {
            DisplayAlert("Warning!", "Please enter a valid check amount", "OK");
            return;
        }

        if (TipPicker.SelectedItem == null)
        {
            DisplayAlert("Warning!", "Please select a tip amount", "OK");
            return;
        }

        if (numPeople <= 0)
        {
            DisplayAlert("Warning!", "Please select number of people", "OK");
            return;
        }

        // retrieve the selected tip amount and percentage
        string selected = TipPicker.SelectedItem.ToString().Replace("%", "");
        tipPercentage = double.Parse(selected);

        eachPersonPays = (totalAmount + (tipPercentage / 100 * totalAmount)) / numPeople;

        // display the amount each person has to pay
        TotalTipLabel.Text = $"Each Person pays: ${eachPersonPays:F2}";
    }
}


