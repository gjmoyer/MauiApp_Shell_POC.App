namespace MauiApp_Shell_POC;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	async void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		await Shell.Current.GoToAsync("//Page1tab1");
    }
}

