using NAudio.Wave;
using System;
using System.IO;

namespace CortadorDeAudio
{
    public class AudioPlayer : IAudioPlayer
    {
        private IWavePlayer wavePlayer;
        private AudioFileReader audioFileReader;

        public bool MusicLoaded { get; set; }

        public string MusicFileName => audioFileReader.FileName;

        public AudioPlayer()
        {
            wavePlayer = new WaveOut();           

            wavePlayer.PlaybackStopped += (sender, e) =>
            {
                if (audioFileReader.Position == audioFileReader.Length)
                    OnPlayerEnds?.Invoke(sender, e);
            };
        }

        public event EventHandler OnPlayerEnds;

        public PlayerStatus PlayerStatus { get; set; }      

        public void LoadMusic(string fileName)
        {
            if (!File.Exists(fileName))
                throw new Exception("file not found!");

            var fileInfo = new FileInfo(fileName);

            if (!fileInfo.Extension.ToUpper().Equals(".MP3"))
                throw new Exception("file must be a mp3!");

            audioFileReader = new AudioFileReader(fileName);

            MusicLoaded = true;

            wavePlayer.Init(audioFileReader);
        }

        public void Play()
        {
            if (!MusicLoaded)
                return;

            wavePlayer.Play();

            PlayerStatus = PlayerStatus.Playing;
        }

        public void Pause()
        {
            if (!MusicLoaded)
                return;

            wavePlayer.Pause();

            PlayerStatus = PlayerStatus.Paused;
        }

        public void Restart()
        {
            if (!MusicLoaded)
                return;

            wavePlayer.Stop();
            audioFileReader.Position = 0;
            wavePlayer.Play();

            PlayerStatus = PlayerStatus.Playing;
        }

        public void Stop()
        {
            if (!MusicLoaded)
                return;

            wavePlayer.Stop();
            audioFileReader.Position = 0;

            PlayerStatus = PlayerStatus.Stopped;
        }

        public void SkipForward(TimeSpan time)
        {
            if (!MusicLoaded)
                return;

            var newTime = audioFileReader.CurrentTime + time;

            audioFileReader.CurrentTime = newTime >= audioFileReader.TotalTime ? time : newTime;
        }

        public void SkipBackward(TimeSpan time)
        {
            if (!MusicLoaded)
                return;

           var newTime = audioFileReader.CurrentTime - time;

            audioFileReader.CurrentTime = newTime <= TimeSpan.Zero ? time : newTime;
        }

        public TimeSpan GetMusicTotalTime()
        {
            if (!MusicLoaded)
                return TimeSpan.Zero;

            return audioFileReader?.TotalTime ?? TimeSpan.Zero;
        }

        public TimeSpan GetMusicCurrentTime()
        {
            if (!MusicLoaded)
                return TimeSpan.Zero;

            return audioFileReader?.CurrentTime ?? TimeSpan.Zero;
        }

        public void SetMusicCurrentTime(TimeSpan time)
        {
            if (!MusicLoaded)
                return;

            var bytesPerMillisecond = audioFileReader.WaveFormat.AverageBytesPerSecond / 1000;

            var position = (int)time.TotalMilliseconds * bytesPerMillisecond;
            position = position - position % audioFileReader.WaveFormat.BlockAlign;

            audioFileReader.Position = position;
        }

        public void SetVolume(float volumeRate)
        {
            if (!MusicLoaded)
                return;

            audioFileReader.Volume = volumeRate;
        }
    }
}
