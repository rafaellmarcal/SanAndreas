using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Trechos.Interfaces
{
    public interface IFiltrarTrechoValido
    {
        List<string> Filtrar(List<string> trechos);
    }
}
