using CallRecordingManager.Models;
using CallRecordingManager.Services;
using CallRecordingManager.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class DisplayByNameView : Page
    {
        public DisplayByNameViewModel viewModel;
        public DisplayByNameView()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {   
            base.OnNavigatedTo(e);
            var parameter = (KeyValuePair<string, RecordViewModel>)e.Parameter;
            viewModel = new DisplayByNameViewModel(parameter.Key,parameter.Value);
            this.DataContext = viewModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var record = (sender as GridView).SelectedItem as CallRecord;
            Frame.Navigate(typeof(MusicPlayerView), record);
        }
    }
}
