namespace Fretty.Views;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;


public partial class FretBoard
{
    private const int NumRows = 7;
    private const int NumCols = 15;
    public FretBoard()
    {
        InitializeComponent();
        GenerateGrid();
        GenerateFretBoard();
        GenerateNote("E", 3, 3);

    }

    private void GenerateGrid()
    {
        // TODO: make height and width dynamic
        for (var i = 0; i < NumRows; i++)
        {
            Grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(50)});
        }
        
        for (var i = 0; i < NumCols; i++)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(59)});
        }
    }

    private void GenerateFretBoard()
    {
        // create the full-width vertical bars
        for (var i = 0; i < NumRows - 1; i++)
        {
            for (var j = 1; j < NumCols + 1; j++)
            {
                Grid.Add(GenerateBoxView(null, LayoutOptions.Start, j == 1 ? 2 : 0.5, null,
                    color: j == 1 ? "#38753F" : "#000000"), j, i);
            }
        }
        
        // create the horizontal bars
        for (var i = 0; i < NumRows - 1; i++)
        {
            for (var j = 1; j < NumCols; j++)
            {
                if (j == 1)
                {
                    // add the half length pieces
                    Grid.Add(GenerateBoxView(null, LayoutOptions.End, 
                        Grid.ColumnDefinitions[0].Width.Value/2, 0.5 * (i+1), color: "#000000"), 
                        0, i);
                    Grid.Add(GenerateBoxView(null, LayoutOptions.Start, 
                        Grid.ColumnDefinitions[0].Width.Value/2, 0.5 * (i+1), color: "#000000"), 
                        NumCols, i);
                } 
                Grid.Add(GenerateBoxView(null, null, null, 0.5 * (i+1), color: "#000000"), 
                    j, i);
            }
        }

    }

    private BoxView GenerateBoxView(LayoutOptions? vertical, LayoutOptions? horizontal, double? width, double? height, 
        string color="#000000")
        
    {
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
    
    private void GenerateNote(string note, int row, int col)
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


    private void KeyChange(object sender, EventArgs e)
    {
        // TODO: Bold active key and draw the correct notes
        var button = (Button) sender;
        button.FontAttributes =
            button.FontAttributes == FontAttributes.Bold ? FontAttributes.None : FontAttributes.Bold;

    }
    
    
}
