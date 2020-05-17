using SanAndreas.Domain.Entities.Cidades.Enumerator;
using SanAndreas.Domain.Entities.Trechos;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Services;
using System.Collections.Generic;
using Xunit;

namespace SanAndreas.Tests.SanAndreas.Domain
{
    public class ConverterTrechoTest
    {
        private IConverterTrecho _converterTrecho;

        public ConverterTrechoTest()
        {
            _converterTrecho = new ConverterTrecho();
        }

        [Fact]
        public void DeveConverterTrechoInformado()
        {
            Trecho expected = NovoTrechoValido();
            List<string> trecho = GerarTrechoValidoEFormatado();

            List<Trecho> result = _converterTrecho.Converter(trecho);

            Assert.Contains(result,
                e => e.CidadeOrigem == expected.CidadeOrigem && e.CidadeDestino == expected.CidadeDestino && e.QuantidadeDias == expected.QuantidadeDias);
        }

        private List<string> GerarTrechoValidoEFormatado()
        {
            return new List<string>()
            {
                "WS;SF;2"
            };
        }

        private Trecho NovoTrechoValido()
        {
            return new Trecho()
            {
                CidadeOrigem = ECidade.WS,
                CidadeDestino = ECidade.SF,
                QuantidadeDias = 2
            };
        }
    }
}
