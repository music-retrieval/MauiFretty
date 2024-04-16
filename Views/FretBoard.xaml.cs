namespace Fretty.Views;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using Microsoft.Maui;
using System.Collections.Generic;

public partial class FretBoard: IFretBoard
{

    private readonly Dictionary<string, object[]> _strings = new ()
    {
        {"E", [0, "#FF97BFFF"]},
        {"B", [1, "#FF97FFA3"]}, 
        {"G", [2, "#FFFF97F3"]}, 
        {"D", [3, "#FFFFD797"]}, 
        {"A", [4, "#FF75FEF6"]},
    };
    
    public FretBoard()
    {
        const int numRows = 7;
        const int numCols = 18;
        InitializeComponent();
        GenerateGrid(numRows, numCols);
        GenerateFretBoard(numRows, numCols);
        GenerateFretDots([[2, 5, 2, 1], [2, 7, 2, 1], [2, 9, 2, 1], [2, 11, 2, 1], [1, 13, 2, 1], [3, 13, 2, 1], [2, 16, 2, 2]]);
    }
    
    public void DrawChord(IEnumerable<int[]> coordinates)
    {
        throw new NotImplementedException();
    }

    private void GenerateTunings(string note, int row)
    {
        List<string> notes = ["A", "B", "C", "D", "E", "F", "G"]; // update this to all possible tunings in better order

        Picker picker = new ()
        {
            Style = (Style)Resources["PickerStyle"],
            ItemsSource = notes,
            SelectedItem = note,
            AutomationId = row.ToString(),
        };
        
        picker.SelectedIndexChanged += OnTuningChanged;
        
        Grid.SetRow((BindableObject)picker, row);
        Grid.SetColumn((BindableObject)picker, 0);
        Grid.Children.Add(picker);
    }

    private static void OnTuningChanged(object? sender, EventArgs e)
    {

        if (sender == null) return;
        Picker picker = (Picker) sender;
        string note = (string) picker.SelectedItem;
        int guitarString = int.Parse(picker.AutomationId);
        UpdateTuning(note, guitarString);

    }
    
    private void GenerateFretDots(IEnumerable<int[]> coordinates)
    {
        foreach (int[] coordinate in coordinates)
        {
            (int x, int y, int rowSpan, int colSpan) = (coordinate[0], coordinate[1], coordinate[2], coordinate[3]);
        
            // Create Ellipse
            Ellipse ellipse = new ()
            {
                Style = (Style)Resources["EllipseStyle"],
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            // Add Ellipse to Grid
            Grid.SetRow((BindableObject)ellipse, x); // Assuming y represents Grid.Row
            Grid.SetColumn((BindableObject)ellipse, y); // Assuming x represents Grid.Column
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
            Grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(rowLength)});
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
            
        
        foreach ((string note, object[] info) in _strings)
        {
            // add the string label and note on beginning of fretboard
            (int index, string color) = ((int)info[0], (string)info[1]);
            GenerateNote(note, color, 1, index);
            GenerateTunings(note, index);
            if (index != 0) continue;
            
            // add the other E note
            GenerateTunings(note, 5);
            GenerateNote(note, color, 1, 5);
        }

    }
    
    private BoxView GenerateBoxView(int i, int j, LayoutOptions? horizontal, LayoutOptions? vertical, 
        double? width, double? height, string color="#000000")
        
    {
        BoxView boxView = new ()
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

        Ellipse circle = new ()
        {
            WidthRequest = 20,
            HeightRequest = 20,
            Fill = Color.FromArgb(color),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };
        
        Label label = new ()
        {
            Text = note,
            FontSize = 16,
            FontAttributes = bolded ? FontAttributes.Bold : FontAttributes.None,
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };
        
        Grid.Add(circle, col, row);
        Grid.Add(label, col, row);
    }


    private void KeyChange(object sender, EventArgs e)
    {
        // TODO: Bold active key and draw the correct notes
    }

    private static void UpdateTuning(string note, int guitarString)
    {
        // TODO: implement this function to update the string that changed
    }
}