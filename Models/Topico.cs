using System;

namespace Forum.Models
{
    public class Topico
    {
        public int Id { get; set; }
        public int Titulo { get; set; }
        public int Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}