using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Encomendas.Interfaces
{
    public interface ICalcularRotaEncomenda
    {
        List<string> Calcular(List<string> encomendas, List<string> trechosCadastrados);
    }
}
