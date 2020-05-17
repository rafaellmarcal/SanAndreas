using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Trechos.Interfaces
{
    public interface IArmazenadorTrecho
    {
        bool Armazenar(List<string> trechos);
    }
}
