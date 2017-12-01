using System;
using NAudio.Lame;
using NAudio.Wave;

namespace CortadorDeAudio
{
    public class AudioTools : IAudioTools
    {
        public void TrimAudio(string filePath, string savePath, TimeSpan from, TimeSpan to)
        {
            using (var reader = new AudioFileReader(filePath))
            {
                using (var writer = new LameMP3FileWriter(savePath, reader.WaveFormat, LAMEPreset.ABR_128))
                {
                    var bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000;

                    var startPos = (int)from.TotalMilliseconds * bytesPerMillisecond;
                    startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

                    var endPos = (int)to.TotalMilliseconds * bytesPerMillisecond;
                    endPos = endPos - endPos % reader.WaveFormat.BlockAlign;                    

                    TrimWavFile(reader, writer, startPos, endPos);
                }
            }
        }

        private static void TrimWavFile(AudioFileReader reader, LameMP3FileWriter writer, int startPos, int endPos)
        {
            reader.Position = startPos;
            var buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                var bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    var bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    var bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
