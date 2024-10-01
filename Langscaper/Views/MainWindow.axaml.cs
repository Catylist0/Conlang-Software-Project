using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Threading.Tasks;

namespace Langscaper.Views
{
    public partial class MainWindow : Window
    {
        private bool isMovedLeft = false;

        public MainWindow()
        {
            InitializeComponent();
            ShowSplashScreen();
        }

        private async void ShowSplashScreen()
        {
            // Load the image directly using AssetLoader
            var splashImage = new Image
            {
                Source = new Bitmap(AssetLoader.Open(new Uri("avares://Langscaper/Assets/Langscaper_Logo.png"))),
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
            };

            // Create a Grid to hold the splash image and add it to the Window's content
            var splashGrid = new Grid();
            splashGrid.Children.Add(splashImage);
            this.Content = splashGrid;

            // Wait for 3 seconds (3000 milliseconds)
            await Task.Delay(3000);

            // Remove the splash screen and show the main content
            InitializeMainContent();
        }

        private void InitializeMainContent()
        {
            // Restore the original content defined in MainWindow.axaml
            this.Content = this.FindControl<StackPanel>("MainStackPanel");
        }

        // Click event handler
        private void OnMoveButtonClick(object sender, RoutedEventArgs e)
        {
            var stackPanel = this.FindControl<StackPanel>("MainStackPanel");

            if (isMovedLeft)
            {
                stackPanel.Margin = new Thickness(0);
                isMovedLeft = false;
            }
            else
            {
                stackPanel.Margin = new Thickness(-200, 0, 0, 0);
                isMovedLeft = true;
            }
        }
    }
}
