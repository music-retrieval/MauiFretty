using Fretty.Views;

namespace Fretty;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		InitRoutes();
	}
	
	private string selectedRoute;
	public string SelectedRoute
	{
		get => selectedRoute;
		set
		{
			if (selectedRoute != value)
			{
				selectedRoute = value;
				OnPropertyChanged();
			}
		}
	}

	private void InitRoutes()
	{
		Routing.RegisterRoute(nameof(ChordStreamer), typeof(ChordStreamer));
		Routing.RegisterRoute(nameof(FretBoard), typeof(FretBoard));
	}
}
