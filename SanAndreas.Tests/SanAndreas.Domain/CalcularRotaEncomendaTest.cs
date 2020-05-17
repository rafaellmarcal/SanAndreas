using SanAndreas.Domain.Entities.Encomendas.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Services;
using System.Collections.Generic;
using Xunit;

namespace SanAndreas.Tests.SanAndreas.Domain
{
    public class CalcularRotaEncomendaTest
    {
        private ICalcularRotaEncomenda _calcularRotaEncomenda;
        private IBuscarMelhorRota _buscarMelhorRota;
        private IConverterTrecho _converterTrecho;
        private IValidadorFormatacaoEncomenda _validadorFormatacaoEncomenda;

        public CalcularRotaEncomendaTest()
        {
            _buscarMelhorRota = new BuscarMelhorRota();
            _converterTrecho = new ConverterTrecho();
            _validadorFormatacaoEncomenda = new ValidadorFormatacaoEncomenda();

            _calcularRotaEncomenda = new CalcularRotaEncomenda(
                _buscarMelhorRota,
                _converterTrecho,
                _validadorFormatacaoEncomenda);
        }

        [Theory]
        [InlineData("SF WS 1")]
        [InlineData("LS LV BC 2")]
        [InlineData("WS SF LV BC 5")]
        public void DeveCalcularRotaParaEntradasValidasEFormatadas(string rota)
        {
            List<string> encomendas = GerarEncomendas();
            List<string> trechos = GerarTrechosValidosEFormatados();

            List<string> result = _calcularRotaEncomenda.Calcular(encomendas, trechos);

            Assert.Contains(rota, result);
        }

        [Fact]
        public void NaoDeveCalcularRotaParaEntradasInvalidas()
        {
            List<string> encomendas = null;
            List<string> trechos = new List<string>();

            List<string> result = _calcularRotaEncomenda.Calcular(encomendas, trechos);

            Assert.Null(result);
        }

        private List<string> GerarEncomendas()
        {
            return new List<string>()
            {
                "SF WS",
                "LS BC",
                "WS BC"
            };
        }

        private List<string> GerarTrechosValidosEFormatados()
        {
            return new List<string>()
            {
                "LS;SF;1",
                "SF;LS;2",
                "LS;LV;1",
                "LV;LS;1",
                "SF;LV;2",
                "LV;SF;2",
                "LS;RC;1",
                "RC;LS;2",
                "SF;WS;1",
                "WS;SF;2",
                "LV;BC;1",
                "BC;LV;1"
            };
        }
    }
}
