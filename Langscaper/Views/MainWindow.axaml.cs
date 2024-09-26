using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Langscaper.Views
{
    public partial class MainWindow : Window
    {
        // To track the current state
        private bool isMovedLeft = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Click event handler
        private void OnMoveButtonClick(object sender, RoutedEventArgs e)
        {
            // Get the StackPanel by its name
            var stackPanel = this.FindControl<StackPanel>("MainStackPanel");

            if (isMovedLeft)
            {
                // Reset margin to move it back to the center
                stackPanel.Margin = new Thickness(0);
                isMovedLeft = false;
            }
            else
            {
                // Move the StackPanel to the left
                stackPanel.Margin = new Thickness(-200, 0, 0, 0);
                isMovedLeft = true;
            }
        }
    }
}
