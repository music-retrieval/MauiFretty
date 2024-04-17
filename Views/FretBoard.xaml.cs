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
    private readonly List<string> _stringTunings = ["E", "B", "G", "D", "A", "E"];
    private bool _numberedNotes;

    private const int Rows = 7;
    private const int Columns = 18;
    
    private static readonly List<int[]> DefaultFrets =
        [[2, 5, 2, 1], [2, 7, 2, 1], [2, 9, 2, 1], [2, 11, 2, 1], [1, 13, 2, 1], [3, 13, 2, 1], [2, 16, 2, 2]];
    
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
    
    public FretBoard(TheoryManager theoryManager)
    {
        _theoryManager = theoryManager;
        _theoryManager.RegisterScaleListener(UpdateScalePicker);
        
        InitializeComponent();
        GenerateGrid(Rows, Columns);
        GenerateFretBoard(Rows, Columns);
        GenerateFretDots(DefaultFrets);
        UpdateScalePicker(["AMajor", "CMajor", "CMinor", "DSharpMajor"]);
    }
    
    private readonly TheoryManager _theoryManager;
    
    /* draw all occurrences of the specified note */
    public void GenerateAllOfNote(string note, IEnumerable<int[]> coordinates, string? numberedNote)
    {
        foreach (int[] coordinate in coordinates)
        {
            string color = (string)_strings[note][1];
            if (coordinate[0] <= 16)
                GenerateNote(numberedNote ?? note, color, coordinate[0], coordinate[1]);
        }
    }
    

    /* generate the tuning dropdowns for the guitar strings */
    private void GenerateTuningDropdowns(string note, int row)
    {
        List<string> notes = ["A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"];
        
        Picker picker = new()
        {
            Style = (Style)Resources["PickerStyle"],
            TextColor = Colors.Transparent,
            ItemsSource = notes,
            SelectedItem = note,
            AutomationId = row.ToString(),
            ZIndex = 0,
        };

        Label label = new()
        {
            Text = note,
            FontSize = 14,
            Padding = 12,
            VerticalOptions = LayoutOptions.Center,
            ZIndex = 0,
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
    
    /* generate the dots on the fret board */
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

    /* generate the grid spacing */
    private void GenerateGrid(int numRows, int numCols)
    {
        const double rowLength = 48;
        const double colLength = 56;
        
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

    /* generate the fret lines and initial tuning */
    private void GenerateFretBoard(int numRows, int numCols)
    {
        // create the full-width vertical bars
        for (int i = 0; i < numRows - 1; i++)
        {
            Grid.Add(GenerateBoxView(i, 2, LayoutOptions.Start, null, 2, null, 
                "#38753F"), 2, i);
            for (int j = 3; j < numCols - 1; j++)
            {
                Grid.Add(GenerateBoxView(i, j, LayoutOptions.Start, null, 0.5, null),
                    j, i);
            }
        }

        // create the horizontal bars
        for (int i = 0; i < numRows - 1; i++)
        {
            for (int j = 1; j < numCols - 1; j++)
            {
                Grid.Add(GenerateBoxView(i, j, null, null, null, 0.5 * (i + 1)), 
                    j, i);
            }
        }

        for (int i = 0; i < _stringTunings.Count; i++)
        {
            // add the string label and note on beginning of fretboard
            string note = _stringTunings[i];
            GenerateTuningDropdowns(note, i);
        }
    }

    /* generate a box view with the specified properties */
    private BoxView GenerateBoxView(int i, int j, LayoutOptions? horizontal, LayoutOptions? vertical, 
        double? width, double? height, string color)
    {
        // generate a box view with a specified color
        BoxView boxView = new()
        {
            Color = Color.FromArgb(color),
            HeightRequest = height ?? Grid.RowDefinitions[i].Height.Value,
            WidthRequest = width ?? Grid.ColumnDefinitions[j].Width.Value,
            VerticalOptions = vertical ?? LayoutOptions.Center,
            HorizontalOptions = horizontal ?? LayoutOptions.Center,
            ZIndex = 0,
        };
        
        return boxView;
    }

    private BoxView GenerateBoxView(int i, int j, LayoutOptions? horizontal, LayoutOptions? vertical,
        double? width, double? height)
    {
        // generate box view with the default colors
        BoxView boxView = new()
        {
            HeightRequest = height ?? Grid.RowDefinitions[i].Height.Value,
            WidthRequest = width ?? Grid.ColumnDefinitions[j].Width.Value,
            VerticalOptions = vertical ?? LayoutOptions.Center,
            HorizontalOptions = horizontal ?? LayoutOptions.Center,
            ZIndex = 0,
        };

        return boxView;
    }

    /* draw a note at the specified coordinates */ 
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
            TextColor = Colors.Black,
            FontSize = 14,
            FontAttributes = bolded ? FontAttributes.Bold : FontAttributes.None,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            ZIndex = 1
        };
        
        Grid.Add(circle, col, row);
        Grid.Add(label, col, row);
    }
    
    /* Note Methods */
    public void DrawChord(string note, IEnumerable<int[]> coordinates)
    {
        foreach (int[] coordinate in coordinates)
        {
            string color = (string)_strings[note][1];
            if (coordinate[0] <= 16)
                GenerateNote(note, color, coordinate[0], coordinate[1]);
        }
    }

    /* regenerate all the string tunings */
    private void RegenerateStringTunings()
    {
        for (int i = 0; i < _stringTunings.Count; i++)
        {
            string note = _stringTunings[i];
            UpdateTuning(note, i);
        }
    }

    /* clear the notes from the specified guitar string */
    private void ClearNotes(int guitarString)
    {
        for (int i = 0; i < Grid.Children.Count; i++)
        {
            IView child = Grid.Children[i];
            // ignore the first column and any children not in the row
            if (Grid.GetRow(child) != guitarString || child.ZIndex == 0) continue;

            Grid.Children.RemoveAt(i);
            i--;
        }
    }
    
    /* Update Methods */

    /* update the tuning for the specified guitar string */
    private void UpdateTuning(string note, int guitarString)
    {
        ClearNotes(guitarString);
        GuitarString guitarStringObj = new(note);
        
        string? scale = ScalePicker.SelectedItem.ToString();
        if (scale is null) return;

        Scales.ScaleName scaleName = Scales.StringToScaleName(scale);
        Dictionary<Note, string> notes = Scales.GetScaleByName(scaleName);
        
        ParseNotes(notes, guitarString, guitarStringObj);
    }

    /* fill the scale picker */
    public void UpdateScalePicker(List<string> scales)
    {
        ScalePicker.ItemsSource = scales;
        ScalePicker.SelectedIndex = 0;
    }
    
    /* loop through the guitar strings and update to new chord */
    private void UpdateChord(string chord)
    {
        Chords.ChordName chordName = Chords.StringToChordName(chord);
        Dictionary<Note, string> notes = Chords.GetChordNotes(chordName);
        
        for (int i = 0; i < _stringTunings.Count; i++)
        {
            ClearNotes(i);
            
            string note = _stringTunings[i];
            GuitarString guitarStringObj = new(note);

            ParseNotes(notes, i, guitarStringObj);
        }
    }
    
    /* update the chord list for the selected scale */
    private void UpdateChordList(IEnumerable<string> chords)
    {
        ChordLayout.Children.Clear();
        
        foreach (string chord in chords)
        {
            if (!chord.EndsWith("Major") && !chord.EndsWith("Minor")) continue;
            
            Button button = new()
            {
                Text = chord,
                BackgroundColor = Colors.Transparent,
                FontSize = 14,
                TextColor = Color.FromArgb("#FF38753F"),
                Padding = 10,
            };

            button.Clicked += OnChordSelected;
            ChordLayout.Add(button);
        }
    }

    /* parse the notes and draw them on the specified guitar string */
    private void ParseNotes(Dictionary<Note, string> notes, int guitarString, GuitarString guitarStringObj)
    {
        foreach (KeyValuePair<Note, string> n in notes)
        {
            int[] frets = guitarStringObj.FretsOfNote(n.Key);
            IEnumerable<int[]> coordinates = new List<int[]>();
            coordinates = frets.Aggregate(coordinates, (current, fret) => 
                current.Append([fret + 1, guitarString]));
            GenerateAllOfNote(n.Key.Letter, coordinates, _numberedNotes ? n.Value : null);
        }   
    }
    
    /* callback for updated tuning */
    private void OnTuningChanged(object? sender, EventArgs e)
    {
        if (sender == null) return;
        Picker picker = (Picker)sender;

        string note = (string)picker.SelectedItem;
        int guitarString = int.Parse(picker.AutomationId);

        _stringTunings[guitarString] = note;
        UpdateTuning(note, guitarString);
    }

    /* callback for toggling number/letter notes */
    private void OnToggleNumberedNotes(object? sender, EventArgs e)
    {
        _numberedNotes = !_numberedNotes;
        RegenerateStringTunings();
    }

    /* callback for updated scale */
    private void OnScaleChanged(object? sender, EventArgs e)
    {
        if (sender == null) return;
        Picker picker = (Picker)sender;

        string scale = (string)picker.SelectedItem;
        if (scale is null) return;
        
        Scales.ScaleName scaleName = Scales.StringToScaleName(scale);
        List<Chords.ChordName> chords = Chords.ChordsInScale(scaleName);
        IEnumerable<string> chordStrings = chords.Select(chord => chord.ToString());
        UpdateChordList(chordStrings);
        RegenerateStringTunings();
    }

    
    /* callback for updated chord */
    private void OnChordSelected(object? sender, EventArgs e)
    {
        if (sender == null) return;
        Button button = (Button)sender;

        if (button.FontAttributes == FontAttributes.Bold)
        {
            button.FontAttributes = FontAttributes.None;
            RegenerateStringTunings();
            return;
        }

        foreach (IView child in ChordLayout.Children)
        {
            if (child is not Button childButton) continue;
            childButton.FontAttributes = FontAttributes.None;
        }
        
        button.FontAttributes = FontAttributes.Bold;
        string chord = button.Text;
        UpdateChord(chord);
    }
}
