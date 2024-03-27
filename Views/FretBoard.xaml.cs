using System.Drawing;

namespace Fretty.Views;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;


public partial class FretBoard
{
    private static readonly Grid Grid = GenerateGrid();
    
    public FretBoard()
    {
        InitializeComponent();
        GenerateFretBoard();
        GenerateNote("E", 3, 3);
        
        // Set the grid as the content of the page
        Content = Grid;
    }

    private static Grid GenerateGrid()
    {
        var grid = new Grid
        {
            BackgroundColor = Colors.White
        };

        // TODO: make height and width dynamic
        for (var i = 0; i < 8; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = 50 });
        }
        
        for (var i = 0; i < 25; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 37.5 });
        }

        return grid;
    }

    private static void GenerateFretBoard()
    {
        // create the full-width vertical bars
        for (var i = 2; i < 6; i++)
        {
            for (var j = 1; j < 25; j++)
            {
                Grid.Add(GenerateBoxView(null, LayoutOptions.Start, j == 1 ? 2 : 0.5, null,
                    color: j == 1 ? "#00FF00" : "#000000"), j, i);
            }
        }
        
        // create the half-width vertical bars
        for (var i = 1; i < 25; i++)
        {
            Grid.Add(GenerateBoxView(LayoutOptions.End, LayoutOptions.Start, i == 1 ? 2 : 0.5, 
                Grid.RowDefinitions[0].Height.Value / 2, color: i == 1 ? "#00FF00" : "#000000"), i, 1);
            
            Grid.Add(GenerateBoxView(LayoutOptions.Start, LayoutOptions.Start, i == 1 ? 2 : 0.5, 
                Grid.RowDefinitions[0].Height.Value / 2, color: i == 1 ? "#00FF00" : "#000000"), i, 6);
        }

        
        // create the horizontal bars
        GridAdd(null, null, null, 0.5, 1, 7, 1, 24);

    }

    private static void GridAdd(LayoutOptions? vertical, LayoutOptions? horizontal, double? width, double? height, int startI, int endI, int startJ, int endJ)
    {
        for (var i = startI; i < endI; i++)
        {
            for (var j = startJ; j < endJ; j++)
            {
                Grid.Add(GenerateBoxView(vertical, horizontal, width, height), j, i);
            }
        }
    }
    private static BoxView GenerateBoxView(LayoutOptions? vertical, LayoutOptions? horizontal, double? width, double? height, string color="#000000")
        
    {
        Console.Write(color);
        var boxView = new BoxView
        {
            Color = Color.FromArgb(color),
            HeightRequest = height ?? Grid.RowDefinitions[0].Height.Value,
            WidthRequest = width ?? Grid.ColumnDefinitions[0].Width.Value,
            VerticalOptions = vertical ?? LayoutOptions.Center,
            HorizontalOptions = horizontal ?? LayoutOptions.Center,
        };
        
        return boxView;
    }
    
    private static void GenerateNote(string note, int row, int col)
    {
        var circle = new Ellipse
        {
            WidthRequest = 18,
            HeightRequest = 18,
            Fill = Colors.Red,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };
        
        var label = new Label
        {
            Text = note,
            FontSize = 16,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        
        Grid.Add(circle, col, row);
        Grid.Add(label, col, row);
    }    
    
}
