using Microsoft.AspNetCore.Http;
using SanAndreas.Application.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Interfaces.Services;
using System.Collections.Generic;
using System.IO;

namespace SanAndreas.Application.Services
{
    public class TrechoApplicationService : ITrechoApplicationService
    {
        private readonly IArmazenadorTrecho _armazenadorTrecho;
        private readonly IRetornarTrechoDisponivel _retornarTrechoDisponivel;

        public TrechoApplicationService(
            IArmazenadorTrecho armazenadorTrecho,
            IRetornarTrechoDisponivel atualizarTrechos)
        {
            _armazenadorTrecho = armazenadorTrecho;
            _retornarTrechoDisponivel = atualizarTrechos;
        }

        public bool AtualizarTrechos(IFormFile trechos)
        {
            List<string> trechosInformados = new List<string>();

            using (StreamReader reader = new StreamReader(trechos.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    trechosInformados.Add(reader.ReadLine());
            }

            List<string> trechosDisponiveis = _retornarTrechoDisponivel.Filtrar(trechosInformados);

            return _armazenadorTrecho.Armazenar(trechosDisponiveis);
        }
    }
}
