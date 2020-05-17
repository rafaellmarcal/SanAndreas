using Microsoft.AspNetCore.Http;
using SanAndreas.Application.Interfaces;
using SanAndreas.Domain.Entities.Encomendas.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System.Collections.Generic;

namespace SanAndreas.Application.Services
{
    public class EncomendaApplicationService : BaseApplicationService, IEncomendaApplicationService
    {
        private readonly IBuscarTrechoCadastrado _buscarTrechoCadastrado;
        private readonly ICalcularRotaEncomenda _calcularRota;
        private readonly IGerarSaidaEncomenda _gerarSaidaEncomendas;

        public EncomendaApplicationService(
            IBuscarTrechoCadastrado buscarTrechoCadastrado,
            ICalcularRotaEncomenda calcularRota,
            IGerarSaidaEncomenda gerarSaidaEncomendas)
        {
            _buscarTrechoCadastrado = buscarTrechoCadastrado;
            _calcularRota = calcularRota;
            _gerarSaidaEncomendas = gerarSaidaEncomendas;
        }

        public byte[] CalcularMelhorRota(IFormFile encomendas)
        {
            List<string> encomendasInformados = base.ObterLinhasArquivo(encomendas);
            List<string> trechosCadastrados = _buscarTrechoCadastrado.Buscar();

            List<string> rotasCalculadasEncomendas = _calcularRota.Calcular(encomendasInformados, trechosCadastrados);

            byte[] arquivoRotas = _gerarSaidaEncomendas.GerarSaida(rotasCalculadasEncomendas);

            return arquivoRotas;
        }
    }
}
