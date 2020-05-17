using SanAndreas.Domain.Entities.Trechos.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Services;
using System.Collections.Generic;
using Xunit;

namespace SanAndreas.Tests.SanAndreas.Domain
{
    public class FiltrarTrechoValidoTest
    {
        private IFiltrarTrechoValido _filtrarTrechoValido;
        private IValidadorFormatacaoTrecho _validarFormatacaoTrecho;

        public FiltrarTrechoValidoTest()
        {
            _validarFormatacaoTrecho = new ValidadorFormatacaoTrecho();
            _filtrarTrechoValido = new FiltrarTrechoValido(_validarFormatacaoTrecho);
        }

        [Fact]
        public void DeveFiltrarTrechosValidos()
        {
            List<string> trechosValidos = GerarTrechosValidos();

            List<string> result = _filtrarTrechoValido.Filtrar(trechosValidos);

            Assert.Equal(trechosValidos.Count, result.Count);
        }

        [Fact]
        public void DeveFiltrarTrechosInvalidos()
        {
            List<string> trechosInvalidos = GerarTrechosInvalidos();

            List<string> result = _filtrarTrechoValido.Filtrar(trechosInvalidos);

            Assert.Empty(result);
        }

        [Fact]
        public void DeveFiltrarTrechosNulos()
        {
            List<string> result = _filtrarTrechoValido.Filtrar(null);

            Assert.Null(result);
        }

        [Fact]
        public void DeveFiltrarTrechosVazios()
        {
            List<string> trechos = new List<string>();

            List<string> result = _filtrarTrechoValido.Filtrar(trechos);

            Assert.Null(result);
        }

        private List<string> GerarTrechosValidos()
        {
            return new List<string>()
            {
                "LS SF 1",
                "SF LS 2",
                "LS LV 1",
                "LV LS 1",
                "SF LV 2"
            };
        }

        private List<string> GerarTrechosInvalidos()
        {
            return new List<string>() {
                "AA SF 1",
                "WS AA 100",
                "WS LV AA",
                "",
                "AAAAAAAAAAA",
                "AAAA AAAA   A",
                "A",
                null
            };
        }
    }
}
