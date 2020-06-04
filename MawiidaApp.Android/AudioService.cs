using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using MawiidaApp.Droid;
using Android.Media;
using Android.Content.Res;
[assembly: Dependency(typeof(AudioService))]

namespace MawiidaApp.Droid
{
    class AudioService : IAudio
    {
        public AudioService()
        { }
        MediaPlayer player = new MediaPlayer();
        public bool PauseAudioFile()
        {
            //var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            //player.Pause();
            if (player.IsPlaying)
                player.Pause();
            else player.Start();
            return player.IsPlaying;
        }

        public void PlayAudioFile(string filePath)
        {
            player.Reset();
            player = new MediaPlayer();
            //var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(filePath);//fd.FileDescriptor, fd.StartOffset, fd.Length
            player.Prepare();
        }
    }
}