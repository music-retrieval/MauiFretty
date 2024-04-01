namespace Fretty.Views;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using Microsoft.Maui;
using System.Collections.Generic;
public partial class FretBoard: IFretBoard
{
    private const int NumRows = 7;
    private const int NumCols = 15;
    private readonly Dictionary<string, object[]> _strings = new Dictionary<string, object[]>
    {
        {"E", [0, 3, "#FF97BFFF"]},
        {"B", [1, 7, "#FF97FFA3"]}, 
        {"G", [2, 5, "#FFFF97F3"]}, 
        {"D", [3, 2, "#FFFFD797"]}, 
        {"A", [4, 6, "#FF75FEF6"]},
    };

    public FretBoard()
    {
        InitializeComponent();
        GenerateGrid();
        GenerateFretBoard();
        DisplayChord([[2, 5], [2, 7], [2, 9], [2, 11], [1, 13], [3, 13], [2, 16]]);
    }
    
    public void DisplayChord(IEnumerable<int[]> coords)
    {
        foreach (int[] coord in coords)
        {
            (int x, int y) = (coord[0], coord[1]);
        
            // Create Ellipse
            Ellipse ellipse = new Ellipse
            {
                Style = (Style)Resources["EllipseStyle"],
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Add Ellipse to Grid
            Grid.SetRow((BindableObject)ellipse, x); // Assuming y represents Grid.Row
            Grid.SetColumn((BindableObject)ellipse, y); // Assuming x represents Grid.Column
            Grid.SetRowSpan((BindableObject)ellipse, 2); // Assuming you want a row span of 2
            Grid.SetColumnSpan((BindableObject)ellipse, 2); // Assuming you want a column span of 2
            Grid.Children.Add(ellipse); // Adding the ellipse to the Grid
        }
    }

    private void GenerateGrid()
    {
        const double rowLength = 50;
        const double colLength = 59;
        
        for (var i = 0; i < NumRows; i++)
        {
            Grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(rowLength)});
        }
        
        
        for (var i = 0; i < NumCols+3; i++)
        {
            // create full-width columns for middle and half-width for beginning and end of fretboard
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(
                colLength / (i is > NumCols or < 2 ? 2 : 1))});
        }

    }

    private void GenerateFretBoard()
    {
        // create the full-width vertical bars
        for (var i = 0; i < NumRows - 1; i++)
        {
            for (var j = 2; j < NumCols + 2; j++)
            {
                Grid.Add(GenerateBoxView(i, j, LayoutOptions.Start, null, j == 2 ? 2 : 0.5, null, color: j == 2 ? "#38753F" : "#000000"), j, i);
            }
        }
        
        // create the horizontal bars
        for (var i = 0; i < NumRows - 1; i++)
        {
            for (var j = 1; j <= NumCols + 1; j++)
            {
                Grid.Add(GenerateBoxView(i, j, null, null, null, 0.5 * (i + 1), color: "#000000"), 
                    j, i);
            }
        }
            
        
        foreach (var (note, info) in _strings)
        {
            // add the string label and note on beginning of fretboard
            var (index, number, color) = ((int)info[0], (int)info[1], (string)info[2]);
            GenerateNote(note, "#00000000", 0, index, bolded: false);
            GenerateNote(note, color, 1, index);
            
            if (index != 0) continue;
            
            // add the other E note
            GenerateNote(note, "#00000000", 0, 5, bolded: false);
            GenerateNote(note, color, 1, 5);
        }

    }

    
    private BoxView GenerateBoxView(int i, int j, LayoutOptions? horizontal, LayoutOptions? vertical, 
        double? width, double? height, string color="#000000")
        
    {
        var boxView = new BoxView
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

        var circle = new Ellipse
        {
            WidthRequest = 20,
            HeightRequest = 20,
            Fill = Color.FromArgb(color),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };
        
        var label = new Label
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
        var button = (Button) sender;
        button.FontAttributes =
            button.FontAttributes == FontAttributes.Bold ? FontAttributes.None : FontAttributes.Bold;

    }
    
}
