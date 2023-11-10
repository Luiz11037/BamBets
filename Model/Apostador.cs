using System;

namespace apiBambets.Model
{
    public class Apostador
    {
        public int Id {get; set;}
        public string? Nome { get; set; }
        public int Numero { get; set; }
        public string? Palpite { get; set; }
    }
}
