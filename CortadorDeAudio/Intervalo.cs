using System;
using System.Globalization;

namespace CortadorDeAudio
{
    public class Intervalo
    {
        

        public Intervalo(TimeSpan Inicio, TimeSpan Final)
        {
            this.Inicio = Inicio;
            this.Final = Final;
        }
        
        public TimeSpan Inicio { get; set; }
        public TimeSpan Final { get; set; }
    }
}
