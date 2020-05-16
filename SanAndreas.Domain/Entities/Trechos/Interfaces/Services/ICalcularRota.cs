using SanAndreas.Domain.Entities.Trechos.Dtos;
using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Trechos.Interfaces.Services
{
    public interface ICalcularRota
    {
        List<RotaDto> Calcular(string siglaOrigem, string siglaDestino);
    }
}
