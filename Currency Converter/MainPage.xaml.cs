namespace Currency_Converter;

public partial class MainPage : ContentPage
{

	// dictionary to hold mock exchang rates
	private readonly Dictionary<string, double> ExchangeRatesDictionary = new()
	{
		{ "USD", 1.0 },     // US Dollar
		{ "EUR", 0.04 },    // Euro
		{ "GBP", 0.73 },    // Pound Sterling
		{ "INR", 87.89 },   // Indian Rupee
		{ "JPY", 110.0 },   // Japanese Yen
		{ "NZD", 1.67 }		// New Zealand Dollar
	};

	public MainPage()
	{
		InitializeComponent();
		LoadCurrencies();
	}

	private void LoadCurrencies()
	{
		var currencies = new List<string>(ExchangeRatesDictionary.Keys);
		FromCurrencyPicker.ItemsSource = currencies;

		// optional: set default values
		FromCurrencyPicker.SelectedItem = "USD";
		ToCurrencyPicker.SelectedItem = "NZD";
	}

    private void OnConvertClicked(System.Object sender, System.EventArgs e)
    {
		double amount = Convert.ToDouble(AmountEntry.Text);

		// the question mark makes the string nullable
		// declaring the variable as nullable
		string? fromRateCurrency = FromCurrencyPicker.SelectedItem.ToString();

		// Could also declare as var, this would auto infer the type behind the scenes
		var toRateCurrency = ToCurrencyPicker.SelectedItem.ToString();

		if (fromRateCurrency != null && toRateCurrency != null)
		{
			double fromRate = ExchangeRatesDictionary[fromRateCurrency];
			double toRate = ExchangeRatesDictionary[toRateCurrency];

			double converted = amount * (toRate / fromRate);

			ResultLabel.Text = $"{amount} {fromRateCurrency} = {converted:F2} {toRateCurrency}";
		}
    }
}


