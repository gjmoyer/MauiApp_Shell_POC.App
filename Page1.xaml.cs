namespace MauiApp_Shell_POC;

public partial class Page1 : ContentPage
{
	public Page1()
	{
		InitializeComponent();
    }

	/// <summary>
	/// initiate process the user requested
	/// </summary>
	/// <param name="arg"></param>
	/// <returns></returns>
	public async Task DoScan(string arg)
	{
        await DisplayAlert("Alert", arg, "OK");
    }
}