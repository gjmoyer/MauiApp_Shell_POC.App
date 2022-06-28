namespace MauiApp_Shell_POC;

public partial class TermsPage : ContentPage
{
	public TermsPage()
	{
		InitializeComponent();
	}

    async void OnAgreeClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//Page1tab1");
	}

    async void OnDisagreeClicked(object sender, EventArgs e)
    {
        // user does not agree, send them back to login
		await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}

