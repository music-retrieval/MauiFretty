using System.Text;
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
		index = index > 0 ? index : filename.LastIndexOf('\\');
		return index > 0 ? filename[(index + 1)..] : filename;
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
		AnalyzeBorder.IsVisible = true;
		AnalyzeBorder.IsEnabled = true;
		DescriptionLabel.IsVisible = false;

		UploadButton.IsVisible = false;
		
		ResultLabel.Text = GetFileName(file);
		
	}

	private void ProcessAudio(object sender, EventArgs e)
	{
		if (_filePath == null) return;
		
		IAudioAnalysis analysis = _essentia.Process(_filePath);
		
		// TODO: Display the chords in a more user-friendly way
		//ResultLabel.Text = $"{analysis.Key()}\n" +
		                   //$"Chords: {string.Join("\n", analysis.Chords().Select(chord => chord.ToString()))}\n";
		                   
		// Update all Xaml objects on the page
		DescriptionLabel.IsVisible = false;
		UploadButton.IsVisible = false;
		InfoBorder.IsEnabled = true;
		InfoBorder.IsVisible = true;
		
		// Add all the chords with a strength > 0.5 to a new list
		List<string> chords = new List<string> { };
		for (var i = 0; i < analysis.Chords().Count(); i++)
		{
			var strength = analysis.Chords().ElementAt(i).Strength;
			if (strength > 0.5)
			{
				chords.Add(analysis.Chords().ElementAt(i).Value.ToString());
			}
		}
		
		// Group chords by their count in a dictionary
		var counts = chords.GroupBy(x => x)
			.ToDictionary(group => group.Key, group => group.Count());
		
		// Sort the dictionary of chords and create a new list containing the 5 most common chords
		var sortedChords = counts.OrderByDescending(x => x.Value)
			.Select(x => x.Key)
			.Take(5)
			.ToList();
		
		// Update Chords.Text with 5 best chords
		// Chords.Text = "Suggested Chords: ";
		ChordValues.Text = "";
		foreach (var key in sortedChords)
		{
			ChordValues.Text += " " + key;
		}
		// Update Key.Text with key
		//Key.Text = "Suggested Key: ";
		KeyValues.Text = $" {analysis.Key().Value}\n";
		
		// Update Scale.Text with Scale
		ScaleValues.Text = "Test Scale"; // Dylan this is where you need to add your scale stuff!!! Let me know if I can assist in any way
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
