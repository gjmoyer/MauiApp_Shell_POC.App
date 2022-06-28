namespace MauiApp_Shell_POC;

public partial class AppShell : Shell
{
	public AppShell(Page1 page1)
	{
		InitializeComponent();

        // when scanaction is picked from menu, page1 will know this
        MessagingCenter.Subscribe<AppShell, string>(page1, "scan", async (sender, arg) =>
        {
            await DisplayAlert("Message received", "arg=" + arg, "OK");
        });

        CurrentItem = loginpage;
    }

	protected override void OnNavigating(ShellNavigatingEventArgs args)
	{
		base.OnNavigating(args);

        //when user navigates in tab, that action is ShellSectionChanged
        // otherwise we know user is selecting from flyout
        if (args.Source == ShellNavigationSource.ShellItemChanged || args.Source == ShellNavigationSource.Unknown)
		{
			switch (args.Target.Location.OriginalString)
			{
                //if user picks page1 on flyout, we need to set to page1 on tab
                case "//Page1tab2":
                case "//Page1tab3":
                    args.Cancel();
                    Current.CurrentItem = page1tab1;
                    break;
                //if user picks page2 on flyout, we need to set to page2 on tab
                case "//Page2tab1":
                case "//Page2tab3":
                    args.Cancel();
					Current.CurrentItem = page2tab2;
                    break;
				//if user picks the scan action, page1 needs to be notified of this desired action (page1 handles scan)
                case "//scanaction":
					args.Cancel();
                    Current.CurrentItem = page1tab1;
                    MessagingCenter.Send<AppShell, string>(this, "scan", "Initiate Scan");
					break;
                default:
					break;
			}
		}

	}
}
