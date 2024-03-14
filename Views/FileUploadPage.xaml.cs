using Fretty.Processing;

namespace Fretty.Views;

public partial class FileUploadPage : ContentPage
{
	private string? _filePath;

	public FileUploadPage()
	{
		InitializeComponent();
	}

	private async void OnUpload(object sender, EventArgs e)
	{
		var localDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		
		// TODO: Further restrict the file types
		var pickOptions = new PickOptions();
		string? file =  await CopyPickedToLocal(pickOptions, localDataDir);
		
		if (file != null)
		{
			_filePath = file;
			UploadButton.Text = "Chosen file: " + file;
			
			Essentia.testMe();
			
			Console.WriteLine(Essentia.getChords(file));
		}
	}
	
	private static async Task<string?> CopyPickedToLocal(PickOptions options, string localAppDataDir)
	{
		string? filePath = null;
		
		try
		{
			FileResult? result = await FilePicker.Default.PickAsync();
			filePath = result != null ? await CacheFile(result) : null;
		}
		catch (Exception e)
		{
			// The user canceled or something went wrong
			Console.WriteLine("Error picking file: " + e.Message);
		}

		return filePath;
	}
	
	private static async Task<string> CacheFile(FileBase file) 
	{
		string localDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string localAudioFile = Path.Combine(localDataDir, file.FileName);
		
		using (var sourceStream = await file.OpenReadAsync())
		using (var destinStream = File.Create(localAudioFile))
		{
			await sourceStream.CopyToAsync(destinStream);
		}
		
		return localAudioFile;
	}
}
