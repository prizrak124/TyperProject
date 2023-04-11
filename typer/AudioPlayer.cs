using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

using Typer.Enums;

namespace Typer
{
    public static class AudioPlayer
    {
        private static MediaPlayer _MediaPlayer;
        public static AudioPlayerStateEnum AudioPlayerState { get; set; }
        static AudioPlayer()
        {
            _MediaPlayer = new MediaPlayer();

            _MediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
            _MediaPlayer.MediaFailed += MediaPlayer_MediaFailed;

            Settings.Instance.VolumeChangedEvent += Settings_VolumeChangedEvent;

            AudioPlayerState = AudioPlayerStateEnum.Stopped;
        }

        public static void Stop() 
        { 
            _MediaPlayer.Stop(); 
            AudioPlayerState = AudioPlayerStateEnum.Stopped;
        }

        public static void Pause()
        {
            _MediaPlayer.Pause();
            AudioPlayerState = AudioPlayerStateEnum.Paused;
        }

        public static void Play() 
        { 
            _MediaPlayer.Play();
            AudioPlayerState = AudioPlayerStateEnum.Played;
        }
        
        public static void SetAudio(FileInfo file) => SetAudio(file.FullName);
        
        public static void SetAudio(string path) => _MediaPlayer.Open(new Uri(path)); 
        
        public static void SetVolume(double volume) => _MediaPlayer.Volume = volume;
        private static void MediaPlayer_MediaFailed(object sender, ExceptionEventArgs e)
        {
            AudioPlayerState = AudioPlayerStateEnum.Stopped;
            MessageBox.Show($"Ошибка воспроизведения: {e.ErrorException.Message}");
        }
        

        private static void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            _MediaPlayer.Position = new TimeSpan(0);
            _MediaPlayer.Play();
        }

        private static void Settings_VolumeChangedEvent(double volume) => SetVolume(volume);
        
    }
}
