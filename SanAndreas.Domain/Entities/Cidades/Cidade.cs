using SanAndreas.Domain.Entities.Trechos;
using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Cidades
{
    public class Cidade
    {
        public long CidadeId { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public virtual List<Trecho> Trechos { get; private set; } = new List<Trecho>();

        protected Cidade() { }
    }
}
