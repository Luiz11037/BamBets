using System;

namespace apiBambets.Model
{
     public class Jogo
    {
        public int Id { get; set;}
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public List<Apostador> apostadores_jogo { get; set; }
    }
}