using System;

namespace CortadorDeAudio
{
    public interface IAudioPlayer
    {
        PlayerStatus PlayerStatus { get; set; }        

        void LoadMusic(string path);

        void SetPosition(decimal position);
        decimal GetPosition();

        void Play();
        void Pause();
        void Stop();
        void Restart();

        void StepAhead(short milliseconds);
        void StepBack(short milliseconds);
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
