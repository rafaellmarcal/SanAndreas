using SanAndreas.Domain.Entities.Cidades.Enumerator;

namespace SanAndreas.Domain.Entities.Trechos
{
    public class Trecho
    {
        public ECidade CidadeOrigem { get; set; }
        public ECidade CidadeDestino { get; set; }
        public int QuantidadeDias { get; set; }
    }
}
