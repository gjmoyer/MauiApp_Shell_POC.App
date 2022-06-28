namespace MauiApp_Shell_POC;

public partial class MainPage : ContentPage
{
	public MainPage(TermsPage terms)
	{
		InitializeComponent();
	}

	async void OnCounterClicked(object sender, EventArgs e)
	{
        //user must agree to terms and conditions before allowing app usage
        //await Shell.Current.GoToAsync($"//{nameof(TermsPage)}");

        // after successful login, this will be our landing page for authenticated users
        await Shell.Current.GoToAsync("//Page1tab1");
    }
}

