namespace MauiApp_Shell_POC;

public partial class AppShell : Shell
{
	public AppShell(Page1 page1)
	{
		InitializeComponent();

        //Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

        // when scanaction is picked from menu, page1 will know this
        MessagingCenter.Subscribe<AppShell, string>(page1, "scan", async (sender, arg) =>
        {
            await DisplayAlert("Message received", "arg=" + arg, "OK");
        });

        // initial landing page will be our login
        CurrentItem = mainpage;
    }

    protected override void OnNavigating(ShellNavigatingEventArgs args)
	{
		base.OnNavigating(args);

        //when user navigates in tab, that action is ShellSectionChanged
        // otherwise we know user is selecting from flyout
        switch (args.Source)
        {
            case ShellNavigationSource.ShellItemChanged:
            case ShellNavigationSource.Unknown:

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

                        //page1 will be subscribing to this message
                        MessagingCenter.Send<AppShell, string>(this, "scan", "Initiate Scan");
                        break;
                    default:
                        break;
                }
                break;

            case ShellNavigationSource.ShellSectionChanged:

                switch (args.Target.Location.OriginalString)
                {
                    //if user picks scan on tabs, we need to set to page1 to handle this action
                    case "//Page1scan":
                    case "//Page2scan":
                        args.Cancel();
                        Current.CurrentItem = page1tab1;

                        //page1 will be subscribing to this message
                        MessagingCenter.Send<AppShell, string>(this, "scan", "Initiate Scan");
                        break;
                }
                break;
        }

	}
}
