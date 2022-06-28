namespace MauiApp_Shell_POC;

public partial class App : Application
{
    // ideally this value stored in database so users only asked once
	public static bool UserTermsAgreed = false;

    public App(AppShell appshell)
	{
		InitializeComponent();

		MainPage = appshell;
	}
}
