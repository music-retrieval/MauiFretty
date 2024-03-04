namespace Fretty.Views;

public partial class FretBoard : ContentPage
{
    private double _startX;
    private double _startY;
    
    public FretBoard()
    {
        InitializeComponent();
        
        // Add Pan Gesture Recognizer
        var panGesture = new PanGestureRecognizer();
        panGesture.PanUpdated += OnPanUpdated;
    }
    
    private async void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        switch (e.StatusType)
        {
            case GestureStatus.Started:
                _startX = e.TotalX;
                _startY = e.TotalY;
                break;
            case GestureStatus.Running:
                var currentX = e.TotalX;
                var currentY = e.TotalY;

                var deltaX = currentX - _startX;
                var deltaY = currentY - _startY;

                // Check if the gesture is more horizontal than vertical
                if (Math.Abs(deltaX) > Math.Abs(deltaY))
                {
                    // Check if the gesture is towards the right
                    if (deltaX > 0)
                    {
                    }
                }
                break;
        }
    }
}