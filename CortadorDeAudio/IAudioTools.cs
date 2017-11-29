using System;

namespace CortadorDeAudio
{
    public interface IAudioTools
    {
        void TrimAudio(string filePath, string savePath, TimeSpan from, TimeSpan to);
    }
}
