namespace Fretty.Views;

public partial class MainPage : ContentPage
{
	int _count;
	string? _file;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnUploadClicked(object sender, EventArgs e)
	{
		var localAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		
		var pickOptions = new PickOptions();
		string? file =  await CopyPickedToLocal(pickOptions, localAppDataDir);
		
		if (file != null)
		{
			_file = file;
			UploadButton.Text = "Chosen file: " + file;
		}
	}
	
	private async Task<string>? CopyPickedToLocal(PickOptions options, string localAppDataDir)
	{
		try
		{
			var result = await FilePicker.Default.PickAsync();
			
			if (result != null)
			{
				string localAudioFile = Path.Combine(localAppDataDir, result.FileName);
				
				using (var sourceStream = await result.OpenReadAsync())
				using (var destinationStream = File.Create(localAudioFile))
				{
					await sourceStream.CopyToAsync(destinationStream);
				}
				
				return localAppDataDir;
			}

			return null;
		}
		catch (Exception ex)
		{
			// The user canceled or something went wrong
		}

		return null;
	}
}

