using Fretty.Processing;
using Fretty.Shared;
using Fretty.Theory;

namespace Fretty.Views;

public partial class FileUploadPage
{
	public FileUploadPage(TheoryManager theoryManager)
	{
		InitializeComponent();
		_essentia = new Essentia(new FrettysEssentia(), theoryManager);
	}
	
	private string? _filePath;
	// TODO: Further restrict file types
	private readonly PickOptions _pickOptions = new();
	private readonly Essentia _essentia;

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
		if (_filePath == null) return;

		IAudioAnalysis analysis = _essentia.Process(_filePath);
		
		// TODO: Display the chords in a more user-friendly way
		ResultLabel.Text = $"{analysis.Key()}\n" +
		                   $"Chords: {string.Join("\n", analysis.Chords().Select(chord => chord.ToString()))}\n";
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
