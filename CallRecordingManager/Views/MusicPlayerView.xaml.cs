using CallRecordingManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CallRecordingManager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MusicPlayerView : Page
    {
        public MusicPlayerView()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameter = (CallRecord)e.Parameter;
            Uri pathUri = new Uri($"ms-appx:///Assets/Audio/{parameter.FileName}");
            MyMediaPlayer.Source = MediaSource.CreateFromUri(pathUri);
            MyMediaPlayer.MediaPlayer.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                MyMediaPlayer.MediaPlayer.Pause();
                MyMediaPlayer.Source = null;
                Frame.GoBack();
            }
        }
    }
}
