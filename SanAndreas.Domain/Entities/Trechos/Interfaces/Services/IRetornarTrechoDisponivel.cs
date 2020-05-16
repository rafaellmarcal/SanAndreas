using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Trechos.Interfaces.Services
{
    public interface IRetornarTrechoDisponivel
    {
        List<string> Filtrar(List<string> trechos);
    }
}
