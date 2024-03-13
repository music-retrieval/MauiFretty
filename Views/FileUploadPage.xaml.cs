using Fretty.Processing;
using Fretty.Shared;

namespace Fretty.Views;

public partial class FileUploadPage
{
	public FileUploadPage()
	{
		InitializeComponent();
	}
	
	private string? _filePath;
	// TODO: Further restrict file types
	private readonly PickOptions _pickOptions = new();
	private readonly Essentia _essentia = new(new FrettysEssentia());

	private async void OnUpload(object sender, EventArgs e)
	{
		string? file =  await CopyPickedToLocal(_pickOptions);
		
		// Something went wrong
		if (file == null) return;
		
		_filePath = file;
		ProcessButton.IsEnabled = true;
		UploadButton.Text = "Chosen file: " + file;
	}

	private void ProcessAudio(object sender, EventArgs e)
	{
		IAudioAnalysis analysis = _filePath != null ? _essentia.Process(_filePath) : FrettysAnalysis.Empty;
		
		// TODO: Display the chords in a more user-friendly way
		string chords = string.Join(" -> ", analysis.Chords());
		ResultLabel.Text = chords;
	}
	
	private static async Task<string?> CopyPickedToLocal(PickOptions options)
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

		await using Stream sourceStream = await file.OpenReadAsync();
		await using FileStream destinStream = File.Create(localAudioFile);
		
		await sourceStream.CopyToAsync(destinStream);
		return localAudioFile;
	}
}
