using Fretty.Processing;
using Fretty.Shared;

namespace Fretty.Views;

public partial class FileUploadPage
{
	public FileUploadPage()
	{
		InitializeComponent();
	}

	private static string GetFileName(string filename)
	{
		int index = filename.LastIndexOf('/');
		if (index > 0) 
		{
			return filename.Substring(index + 1);
		}
		else
		{
			return filename;
		}
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
		ProcessButton.IsVisible = true;
		
		UploadButton.Text = "Upload another file";
		UploadButton.FontSize = 36;
		
		ResultLabel.Text = GetFileName(file);
	}

	private void ProcessAudio(object sender, EventArgs e)
	{
		if (_filePath == null) return;

		IAudioAnalysis analysis = _essentia.Process(_filePath);
		
		// TODO: Display the chords in a more user-friendly way
		ResultLabel.Text = $"{analysis.Key()}\n" +
		                   $"Chords: {string.Join("\n", analysis.Chords().Select(chord => chord.ToString()))}\n";

		// Update all Xaml objects on the page
		DescriptionLabel.IsVisible = false;
		UploadButton.IsVisible = false;
		ResultBorder.IsEnabled = true;
		ResultBorder.IsVisible = true;
		InfoBorder.IsEnabled = true;
		InfoBorder.IsVisible = true;
		
		// TODO: Put actual values into these 
		Key.Text = "Key:    " + "C Major";
		Scale.Text = "Suggested Scale:    " + "A Minor Pentatonic";
		Chords.Text = "Chords Found:    " + "C   Dm   F";
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
