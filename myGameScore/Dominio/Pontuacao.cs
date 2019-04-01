using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pontuacao
    {
        public int idPontuacao { get; set; }
        public DateTime dataPontuacao { get; set; }
        public int pontos { get; set; }
        public int IdJogador { get; set; }
    }
}
