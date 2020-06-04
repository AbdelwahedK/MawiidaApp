using System;
using Xamarin.Forms;
using MawiidaApp;
using MawiidaApp.iOS;
using System.IO;
using Foundation;
using AVFoundation;
[assembly: Dependency(typeof(AudioService))]

namespace MawiidaApp.iOS
{
    class AudioService : IAudio
    {
        AVAudioPlayer _player;
        public AudioService()
        { }

        public bool PauseAudioFile()
        {
            if (_player.Playing) _player.Pause();
            else _player.Play();
            return _player.Playing;
        }

        public void PlayAudioFile(string fileName)
        {
            //NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName))
            _player.Stop();
            string sFilePath = fileName;
            var url = NSUrl.FromString(sFilePath);
            _player = AVAudioPlayer.FromUrl(url);
            _player.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
            {
                _player = null;
            };
            _player.Play();
        }

    }
}