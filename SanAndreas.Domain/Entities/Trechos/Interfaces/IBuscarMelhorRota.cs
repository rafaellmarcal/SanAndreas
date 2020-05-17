using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Trechos.Interfaces
{
    public interface IBuscarMelhorRota
    {
        string Buscar(string encomenda, List<Trecho> trechosCadastrados);
    }
}
