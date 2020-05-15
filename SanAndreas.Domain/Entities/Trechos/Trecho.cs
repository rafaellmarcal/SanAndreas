using SanAndreas.Domain.Entities.Cidades;

namespace SanAndreas.Domain.Entities.Trechos
{
    public class Trecho
    {
        public int CidadeOrigemId { get; private set; }
        public int CidadeDestinoId { get; private set; }
        public int QuantidadeDias { get; private set; }

        public virtual Cidade CidadeDestino { get; private set; }
        public virtual Cidade CidadeOrigem { get; private set; }

        protected Trecho() { }
    }
}
