namespace MauiApp_Shell_POC;

public partial class MainPage : ContentPage
{
	public MainPage(TermsPage terms)
	{
		InitializeComponent();
	}

	/// <summary>
	/// user entered credentials and is authenticated at this stage
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	async void OnLoginClicked(object sender, EventArgs e)
	{
		if (App.UserTermsAgreed)
		{
            // after successful login, this will be our landing page for authenticated users
            // replace the nav stack via double slash
            await Shell.Current.GoToAsync("//Page1tab1");
        }
		else
		{
            //user must agree to terms and conditions before allowing app usage
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}/{nameof(TermsPage)}");
        }
    }
}

