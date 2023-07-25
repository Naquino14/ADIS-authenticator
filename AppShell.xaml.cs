namespace ADIS_authenticator;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CamPopUp), typeof(CamPopUp));
	}
}
