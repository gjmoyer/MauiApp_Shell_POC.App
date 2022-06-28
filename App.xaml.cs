namespace MauiApp_Shell_POC;

public partial class App : Application
{
	public App(AppShell appshell)
	{
		InitializeComponent();

		MainPage = appshell;
	}
}
