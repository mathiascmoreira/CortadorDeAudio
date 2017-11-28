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

        public void SetPosition(decimal position)
        {
            if (!MusicLoaded)
                return;

            audioFileReader.Position = Convert.ToInt64(audioFileReader.Length * position);

        }
        public decimal GetPosition()
        {
            if (!MusicLoaded)
                return 0;

            return Convert.ToDecimal(audioFileReader.Position) / Convert.ToDecimal(audioFileReader.Length);
        }

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

        public void LoadMusic(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Arquivo não existe!");

            var fileInfo = new FileInfo(path);

            if (!fileInfo.Extension.ToUpper().Equals(".MP3"))
                throw new Exception("Arquivo deve ser mp3!");

            audioFileReader = new AudioFileReader(path);

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

        public void StepAhead(short milliseconds)
        {
            if (!MusicLoaded)
                return;

            audioFileReader.CurrentTime = audioFileReader.CurrentTime + new TimeSpan(0, 0, 0, 0, milliseconds);
        }

        public void StepBack(short milliseconds)
        {
            if (!MusicLoaded)
                return;

            audioFileReader.CurrentTime = audioFileReader.CurrentTime - new TimeSpan(0, 0, 0, 0, milliseconds);
        }

        public TimeSpan GetMusicTotalTime()
        {
            return audioFileReader?.TotalTime ?? TimeSpan.Zero;
        }

        public TimeSpan GetMusicCurrentTime()
        {
            return audioFileReader?.CurrentTime ?? TimeSpan.Zero;
        }

        public void SetMusicCurrentTime(TimeSpan time)
        {
            if (!MusicLoaded)
                return;

            audioFileReader.CurrentTime = time;
        }
    }
}
