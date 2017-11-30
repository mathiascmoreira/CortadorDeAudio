using System;

namespace CortadorDeAudio
{
    public interface IAudioPlayer
    {
        PlayerStatus PlayerStatus { get; set; }        

        void LoadMusic(string path);

        string MusicFileName { get; }

        bool MusicLoaded { get; set; }
       
        void Play();
        void Pause();
        void Stop();
        void Restart();

        void StepAhead(TimeSpan time);
        void StepBack(TimeSpan time);
        TimeSpan GetMusicTotalTime();
        TimeSpan GetMusicCurrentTime();
        void SetMusicCurrentTime(TimeSpan time);

        event EventHandler OnPlayerEnds;
    }

    public enum PlayerStatus
    {
        None,
        Playing,
        Paused,
        Stopped
    }
}
