using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MawiidaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class playAudioPage : ContentPage
    {
        public playAudioPage()
        {
            InitializeComponent();
            //var navigationPage = Application.Current.MainPage as NavigationPage;
            //navigationPage.BarBackgroundColor = Color.FromHex("#2FA999");
            //navigationPage.Title = "إنشاء حلقة جديدة";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //"7ARI - MONOPOLY (prod by enywayz)(MP3_128K).mp3"
            FileData file = await CrossFilePicker.Current.PickFile();
            //await DisplayAlert("File path", file.FilePath.Replace("content://", ""), "ok");

            if (file != null)
            {
                lbl.Text = file.FileName;
                DependencyService.Get<IAudio>().PlayAudioFile(file.FilePath.Replace("content://", ""));
            }
        }
        private void Pause_Clicked(object sender, EventArgs e)
        {
            bool isPlaying = DependencyService.Get<IAudio>().PauseAudioFile();
            _ = isPlaying == true ? playpausebtn.Source = "pause.png" : playpausebtn.Source = "play.png";
        }
    }
}