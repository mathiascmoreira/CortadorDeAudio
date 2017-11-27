using NAudio.Wave;
using System;
using System.IO;

namespace CortadorDeAudio
{
    public class AudioPlayer : IAudioPlayer
    {
        private IWavePlayer wavePlayer;
        private AudioFileReader audioFileReader;      

        private bool MusicLoaded { get; set; }

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

        public TimeSpan GetMusicTotalTime()
        {
            return audioFileReader?.TotalTime ?? TimeSpan.Zero;
        }

        public TimeSpan GetMusicCurrentTime()
        {
            return audioFileReader?.CurrentTime ?? TimeSpan.Zero;
        }

        public void DecreaseSpeed()
        {
            throw new NotImplementedException();
        }

        public void DecreaseVolume()
        {
            throw new NotImplementedException();
        }

        public void DeleteAllMarkedPositions()
        {
            throw new NotImplementedException();
        }

        public void DeleteAllSelections()
        {
            throw new NotImplementedException();
        }

        public void DeleteCurrentSelection()
        {
            throw new NotImplementedException();
        }

        public void EndSelection()
        {
            throw new NotImplementedException();
        }

        public void IncreaseSpeed()
        {
            throw new NotImplementedException();
        }

        public void IncreaseVolume()
        {
            throw new NotImplementedException();
        }

        public void MarkPosition()
        {
            throw new NotImplementedException();
        }

        public void NextMarkedPosition(bool pause = false)
        {
            throw new NotImplementedException();
        }

        public void NextMusic()
        {
            throw new NotImplementedException();
        }

        public void NextSelection(bool pause = false)
        {
            throw new NotImplementedException();
        }

        public void PreviousMarkedPosition(bool pause = false)
        {
            throw new NotImplementedException();
        }

        public void PreviousMusic()
        {
            throw new NotImplementedException();
        }

        public void PreviousSelection(bool pause = false)
        {
            throw new NotImplementedException();
        }

        public void SaveSelectionsAsSeparateFiles()
        {
            throw new NotImplementedException();
        }

        public void SelectBetweenTwoMarkedPosition()
        {
            throw new NotImplementedException();
        }

        public void SetSpeed(decimal speed)
        {
            throw new NotImplementedException();
        }

        public void StartSelection()
        {
            throw new NotImplementedException();
        }

        public void UnSelectAllSelections()
        {
            throw new NotImplementedException();
        }

        public void UnselectCurrentSelection()
        {
            throw new NotImplementedException();
        }
    }
}
