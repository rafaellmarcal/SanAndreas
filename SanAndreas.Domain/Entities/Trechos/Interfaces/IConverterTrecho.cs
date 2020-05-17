using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Trechos.Interfaces
{
    public interface IConverterTrecho
    {
        List<Trecho> Converter(List<string> trechosCadastrados);
    }
}
