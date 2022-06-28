namespace MauiApp_Shell_POC;

public partial class TermsPage : ContentPage
{
	public TermsPage()
	{
		InitializeComponent();

        SetBinding();
    }

    async void OnAgreeClicked(object sender, EventArgs e)
	{
        //ideally this is saved to database
        App.UserTermsAgreed = true;

        SetBinding();

        // our stack now starts with our page1
        await Shell.Current.GoToAsync("//Page1tab1");
	}

    async void OnDisagreeClicked(object sender, EventArgs e)
    {
        // user does not agree, send back to login
		await Shell.Current.GoToAsync($"..");
    }

    void SetBinding()
    {
        BindingContext = new
        {
            IsLogin = !App.UserTermsAgreed
        };
    }
}

