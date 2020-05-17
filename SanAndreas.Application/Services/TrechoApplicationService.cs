using Microsoft.AspNetCore.Http;
using SanAndreas.Application.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System.Collections.Generic;

namespace SanAndreas.Application.Services
{
    public class TrechoApplicationService : BaseApplicationService, ITrechoApplicationService
    {
        private readonly IArmazenadorTrecho _armazenadorTrecho;
        private readonly IFiltrarTrechoValido _filtrarTrechoValido;

        public TrechoApplicationService(
            IArmazenadorTrecho armazenadorTrecho,
            IFiltrarTrechoValido filtrarTrechoValido)
        {
            _armazenadorTrecho = armazenadorTrecho;
            _filtrarTrechoValido = filtrarTrechoValido;
        }

        public bool AtualizarTrechos(IFormFile trechos)
        {
            List<string> trechosInformados = base.ObterLinhasArquivo(trechos);

            List<string> trechosValidos = _filtrarTrechoValido.Filtrar(trechosInformados);

            return _armazenadorTrecho.Armazenar(trechosValidos);
        }
    }
}
