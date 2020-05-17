using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Encomendas.Interfaces
{
    public interface IGerarSaidaEncomenda
    {
        byte[] GerarSaida(List<string> rotasCalculadasEncomendas);
    }
}
