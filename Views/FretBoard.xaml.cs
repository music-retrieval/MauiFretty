namespace Fretty.Views;

using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using Microsoft.Maui;
using System.Collections.Generic;
using Theory;

public partial class FretBoard : IFretBoard
{
    private readonly List<string> _defaultStrings = ["E", "B", "G", "D", "A", "E"];
    
    private readonly Dictionary<string, object[]> _strings = new()
    {
        { "A", [0, "#FF75FEF6"] },
        { "A#", [1, "#FF53DCD4"] },
        { "B", [2, "#FF97FFA3"] },
        { "C", [3, "#FFB175FE"] },
        { "C#", [4, "#FF9053DC"] },
        { "D", [5, "#FFFFD797"] },
        { "D#", [6, "#FFFDDB75"] },
        { "E", [7, "#FF97BFFF"] },
        { "F", [8, "#FFFE757D"] },
        { "F#", [9, "#FFDC535B"] },
        { "G", [10, "#FFFF97F3"] },
        { "G#", [11, "#FFDD75D1"] },
    };

    private readonly List<string> _scalesPicker = ["AMajor", "AMinor", "CMajor", "DSharpMajor"]; // placeholder
    
    public FretBoard(TheoryManager theoryManager)
    {
        const int numRows = 7;
        const int numCols = 18;
        InitializeComponent();
        UpdateScalePicker(theoryManager.AvailableScales());
        GenerateGrid(numRows, numCols);
        GenerateFretBoard(numRows, numCols);
        GenerateFretDots([[2, 5, 2, 1], [2, 7, 2, 1], [2, 9, 2, 1], [2, 11, 2, 1], [1, 13, 2, 1], [3, 13, 2, 1], [2, 16, 2, 2]]);
    }

    public void DrawChord(string note, IEnumerable<int[]> coordinates)
    {
        foreach (int[] coordinate in coordinates)
        {
            string color = (string)_strings[note][1];
            if (coordinate[0] <= 16)
                GenerateNote(note, color, coordinate[0], coordinate[1]);
        }
    }

    private void GenerateTunings(string note, int row)
    {
        List<string> notes = ["A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"];

        Picker picker = new()
        {
            Style = (Style)Resources["PickerStyle"],
            ItemsSource = notes,
            SelectedItem = note,
            AutomationId = row.ToString(),
        };

        Label label = new()
        {
            Text = note,
            FontSize = 14,
            TextColor = Colors.Black,
            Padding = 12,
            VerticalOptions = LayoutOptions.Center,
        };
        
        picker.SelectedIndexChanged += (sender, args) =>
        {
            string selectedItem = (string)picker.SelectedItem;
            label.Text = selectedItem;
            OnTuningChanged(sender, args);
        };
        
        Grid.SetRow((BindableObject)label, row);
        Grid.SetColumn((BindableObject)label, 0);
        Grid.Children.Add(label);
        
        Grid.SetRow((BindableObject)picker, row);
        Grid.SetColumn((BindableObject)picker, 0);
        Grid.Children.Add(picker);
    }

    private void OnTuningChanged(object? sender, EventArgs e)
    {
        if (sender == null) return;
        Picker picker = (Picker)sender;

        string note = (string)picker.SelectedItem;
        int guitarString = int.Parse(picker.AutomationId);
        UpdateTuning(note, guitarString);
    }

    private void OnScaleChanged(object? sender, EventArgs e)
    {
        if (sender == null) return;
        Picker picker = (Picker)sender;
        
        string scale = (string)picker.SelectedItem;
        Scales.ScaleName scaleName = Scales.StringToScaleName(scale);
        List<Chords.ChordName> chords = Chords.ChordsInScale(scaleName);
        IEnumerable<string> chordStrings = chords.Select(chord => chord.ToString());
        UpdateChords(chordStrings);
    }
    
    private void GenerateFretDots(IEnumerable<int[]> coordinates)
    {
        foreach (int[] coordinate in coordinates)
        {
            (int x, int y, int rowSpan, int colSpan) = (coordinate[0], coordinate[1], coordinate[2], coordinate[3]);
        
            // Create Ellipse
            Ellipse ellipse = new()
            {
                Style = (Style)Resources["EllipseStyle"],
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                ZIndex = 0
            };

            // Add Ellipse to Grid
            Grid.SetRow((BindableObject)ellipse, x);
            Grid.SetColumn((BindableObject)ellipse, y);
            Grid.SetRowSpan((BindableObject)ellipse, rowSpan);
            Grid.SetColumnSpan((BindableObject)ellipse, colSpan);
            
            Grid.Children.Add(ellipse);
        }
    }

    private void GenerateGrid(int numRows, int numCols)
    {
        const double rowLength = 50;
        const double colLength = 58;
        
        for (int i = 0; i < numRows; i++)
        {
            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(rowLength) });
        }
        
        
        for (int i = 0; i < numCols; i++)
        {
            // create full-width columns for middle and half-width for beginning and end of fretboard
            Grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(
                    colLength / (i > numCols - 3 || i == 1 ? 2 : 1))
            });
        }
    }

    private void GenerateFretBoard(int numRows, int numCols)
    {
        // create the full-width vertical bars
        for (int i = 0; i < numRows - 1; i++)
        {
            for (int j = 2; j < numCols - 1; j++)
            {
                Grid.Add(GenerateBoxView(i, j, LayoutOptions.Start, null, j == 2 ? 2 : 0.5, null, color: j == 2 ? "#38753F" : "#000000"), j, i);
            }
        }
        
        // create the horizontal bars
        for (int i = 0; i < numRows - 1; i++)
        {
            for (int j = 1; j < numCols - 1; j++)
            {
                Grid.Add(GenerateBoxView(i, j, null, null, null, 0.5 * (i + 1), color: "#000000"), 
                    j, i);
            }
        }

        
        for (int i = 0; i < _defaultStrings.Count; i++)
        {
            // add the string label and note on beginning of fretboard
            string note = _defaultStrings[i];
            UpdateTuning(note, i);
            GenerateTunings(note, i);
        }
    }

    private BoxView GenerateBoxView(int i, int j, LayoutOptions? horizontal, LayoutOptions? vertical, 
        double? width, double? height, string color = "#000000")
    {
        BoxView boxView = new()
        {
            Color = Color.FromArgb(color),
            HeightRequest = height ?? Grid.RowDefinitions[i].Height.Value,
            WidthRequest = width ?? Grid.ColumnDefinitions[j].Width.Value,
            VerticalOptions = vertical ?? LayoutOptions.Center,
            HorizontalOptions = horizontal ?? LayoutOptions.Center,
        };
        
        return boxView;
    }

    private void GenerateNote(string note, string color, int col, int row, bool bolded = true)
    {
        Ellipse circle = new()
        {
            WidthRequest = 25,
            HeightRequest = 25,
            Fill = Color.FromArgb(color),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            ZIndex = 1
        };
        
        Label label = new()
        {
            Text = note,
            FontSize = 14,
            FontAttributes = bolded ? FontAttributes.Bold : FontAttributes.None,
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            ZIndex = 1
        };
        
        Grid.Add(circle, col, row);
        Grid.Add(label, col, row);
    }

    private void KeyChange(object sender, EventArgs e)
    {
        // TODO: Bold active key and draw the correct notes
    }

    private void ClearRow(int row)
    {
            for (int i = 0; i < Grid.Children.Count; i++)
            {
                IView child = Grid.Children[i];
                // ignore the first column and any children not in the row
                if (Grid.GetRow(child) != row || Grid.GetColumn(child) == 0) continue;
                
                // ignore the strings and tunings
                if (child is BoxView or Picker) continue;

                Grid.Children.RemoveAt(i);
                i--;
            }
    }

    private void UpdateTuning(string note, int guitarString)
    {
        ClearRow(guitarString);
        GuitarString guitarStringObj = new(note);
        
        string? scale = ScalePicker.SelectedItem.ToString();
        if (scale is null) return;

        Scales.ScaleName scaleName = Scales.StringToScaleName(scale);
        Dictionary<Note, string> notes = Scales.GetScaleByName(scaleName);

        foreach (KeyValuePair<Note, string> n in notes)
        {
            int[] frets = guitarStringObj.FretsOfNote(n.Key);
            IEnumerable<int[]> coordinates = new List<int[]>();
            coordinates = frets.Aggregate(coordinates, (current, fret) => 
                current.Append([fret + 1, guitarString]));
            DrawChord(n.Key.Letter, coordinates);
        }
    }

    public void UpdateScalePicker(List<string> scales)
    {
        ScalePicker.ItemsSource = scales;
        ScalePicker.SelectedIndex = 0;
    }

    private void UpdateChords(IEnumerable<string> chords)
    {
        ChordLayout.Children.Clear();
        
        foreach (string chord in chords)
        {
            if (!chord.EndsWith("Major") && !chord.EndsWith("Minor")) continue;
            
            Label label = new()
            {
                Text = chord,
                FontSize = 14,
                TextColor = Color.FromArgb("#FF38753F"),
                Padding = 10,
            };
            ChordLayout.Add(label);
        }
    }
}
