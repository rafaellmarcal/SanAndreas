using SanAndreas.Domain.Entities.Encomendas.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Services;
using Xunit;

namespace SanAndreas.Tests.SanAndreas.Domain
{
    public class ValidadorFormatacaoEncomendaTest
    {
        private IValidadorFormatacaoEncomenda _validadorFormatacaoEncomenda;

        public ValidadorFormatacaoEncomendaTest()
        {
            _validadorFormatacaoEncomenda = new ValidadorFormatacaoEncomenda();
        }

        [Theory]
        [InlineData("LS SF")]
        [InlineData("WS LV")]
        [InlineData("RC WS")]
        public void DeveValidarEncomendaComCidadesValidas(string encomenda)
        {
            string result = _validadorFormatacaoEncomenda.Validar(encomenda);

            Assert.True(!string.IsNullOrWhiteSpace(result));
        }

        [Theory]
        [InlineData("AA SF")]
        [InlineData("WS CC")]
        [InlineData("")]
        [InlineData("AAAAAAAAAAA")]
        [InlineData("AAAA   A")]
        [InlineData("A")]
        [InlineData(null)]
        public void DeveValidarEncomendaComCidadesInvalidas(string encomenda)
        {
            string result = _validadorFormatacaoEncomenda.Validar(encomenda);

            Assert.True(string.IsNullOrWhiteSpace(result));
        }
    }
}
