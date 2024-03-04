namespace Fretty.Views;

public partial class MainPage : ContentPage
{
	int _count;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		_count++;
		CounterBtn.Text = $"Current count: {_count}";
	}
}

