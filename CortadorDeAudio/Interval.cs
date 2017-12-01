using System;

namespace CortadorDeAudio
{
    public class Interval
    {
        public Interval(TimeSpan Begin, TimeSpan End)
        {
            this.Begin = Begin;
            this.End = End;
        }
        
        public TimeSpan Begin { get; set; }
        public TimeSpan End { get; set; }
    }
}
