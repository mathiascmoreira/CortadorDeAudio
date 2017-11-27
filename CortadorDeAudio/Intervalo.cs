using System;

namespace CortadorDeAudio
{
    public class Intervalo
    {
        public Intervalo(string inicio, string final)
        {
            Inicio = inicio;
            Final = final;
        }

        public string Inicio { get; set; }
        public string Final { get; set; }
    }
}
