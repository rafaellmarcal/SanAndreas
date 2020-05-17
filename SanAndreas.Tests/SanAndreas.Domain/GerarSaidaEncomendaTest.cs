using SanAndreas.Domain.Entities.Encomendas.Interfaces;
using SanAndreas.Domain.Entities.Encomendas.Services;
using System.Collections.Generic;
using Xunit;

namespace SanAndreas.Tests.SanAndreas.Domain
{
    public class GerarSaidaEncomendaTest
    {
        private IGerarSaidaEncomenda _gerarSaidaEncomenda;

        public GerarSaidaEncomendaTest()
        {
            _gerarSaidaEncomenda = new GerarSaidaEncomenda();
        }

        [Fact]
        public void DeveGerarSaidaParaEntradaValida()
        {
            List<string> rotasCalculadas = GerarRotasCalculadas();

            byte[] result = _gerarSaidaEncomenda.GerarSaida(rotasCalculadas);

            Assert.NotNull(result);
        }

        [Fact]
        public void NaoDeveGerarSaidaParaEntradaVazia()
        {
            List<string> rotasCalculadas = new List<string>();

            byte[] result = _gerarSaidaEncomenda.GerarSaida(rotasCalculadas);

            Assert.Null(result);
        }

        [Fact]
        public void NaoDeveGerarSaidaParaEntradaNula()
        {
            List<string> rotasCalculadas = null;

            byte[] result = _gerarSaidaEncomenda.GerarSaida(rotasCalculadas);

            Assert.Null(result);
        }

        private List<string> GerarRotasCalculadas()
        {
            return new List<string>()
            {
                "SF WS 1",
                "LS LV BC 2",
                "WS SF LV BC 5"
            };
        }
    }
}
