using SanAndreas.Domain.Entities.Trechos.Dtos;
using SanAndreas.Domain.Entities.Trechos.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class CalcularRota : ICalcularRota
    {
        public CalcularRota()
        {

        }

        public List<RotaDto> Calcular(string siglaOrigem, string siglaDestino)
        {
            throw new NotImplementedException();
        }
    }
}
