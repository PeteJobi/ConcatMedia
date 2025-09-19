using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ConcatMediaPage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ConcatMedia
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string outputFile)
            {
                Console.WriteLine($"Path of output file is {outputFile}");
            }
        }

        private async void GoToConcat()
        {
            try
            {
                string ffmpegPath;
                try
                {
                    ffmpegPath = Path.Join(Package.Current.InstalledLocation.Path, "Assets/ffmpeg.exe");
                }
                catch (InvalidOperationException)
                {
                    ffmpegPath = "Assets/ffmpeg.exe";
                }
                if (!File.Exists(ffmpegPath))
                {
                    await ErrorDialog.ShowAsync();
                    return;
                }
                Frame.Navigate(typeof(ConcatMediaPage.ConcatMediaPage), new ConcatProps() { FfmpegPath = ffmpegPath, MediaPaths = [], TypeToNavigateTo = typeof(MainPage).FullName });
            }
            catch (Exception ex)
            {
                ErrorDialog.Content = $"An error occurred while navigating to the concat media page: {ex.Message}";
                await ErrorDialog.ShowAsync();
                System.Diagnostics.Debug.WriteLine($"Error navigating to ConcatMediaPage: {ex.Message}");
            }
        }

        private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            GoToConcat();
        }
    }
}
