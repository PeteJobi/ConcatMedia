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
        private TitleBar _titleBar;
        private string? _ffmpegPath;
        private readonly EventHandler<IList<string>> _filesDropped;
        private readonly EventHandler<string> _ffmpegSet;
        public readonly string[] supportedTypes = ConcatMediaPage.ConcatMediaPage.AllSupportedTypes;

        public MainPage()
        {
            InitializeComponent();
            _filesDropped = (_, paths) => GoToConcat(paths);
            _ffmpegSet = (_, path) => _ffmpegPath = path;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is TitleBar titleBar)
            {
                _titleBar = titleBar;
                return;
            }
            _titleBar.IsBackButtonVisible = false;

            if (e.Parameter is string outputFile)
            {
                Console.WriteLine($"Path of output file is {outputFile}");
            }
        }

        private void GoToConcat(IEnumerable<string> mediaPaths)
        {
            if (_ffmpegPath == null) return;
            Frame.Navigate(typeof(ConcatMediaPage.ConcatMediaPage), new ConcatProps { FfmpegPath = _ffmpegPath, MediaPaths = mediaPaths, TypeToNavigateTo = typeof(MainPage).FullName });
            _titleBar.IsBackButtonVisible = true;
        }
    }
}
