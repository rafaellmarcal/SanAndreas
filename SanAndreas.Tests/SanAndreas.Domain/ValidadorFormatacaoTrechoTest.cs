using SanAndreas.Domain.Entities.Trechos.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Services;
using Xunit;

namespace SanAndreas.Tests.SanAndreas.Domain
{
    public class ValidadorFormatacaoTrechoTest
    {
        private IValidadorFormatacaoTrecho _validadorFormatacaoTrecho;

        public ValidadorFormatacaoTrechoTest()
        {
            _validadorFormatacaoTrecho = new ValidadorFormatacaoTrecho();
        }

        [Theory]
        [InlineData("LS SF 1")]
        [InlineData("WS LV 100")]
        [InlineData("RC WS 100")]
        public void DeveValidarTrechoComCidadeEDiasValidos(string trecho)
        {
            string result = _validadorFormatacaoTrecho.Validar(trecho);

            Assert.True(!string.IsNullOrWhiteSpace(result));
        }

        [Theory]
        [InlineData("AA SF 1")]
        [InlineData("WS AA 100")]
        [InlineData("WS LV AA")]
        [InlineData("")]
        [InlineData("AAAAAAAAAAA")]
        [InlineData("AAAA AAAA   A")]
        [InlineData("A")]
        [InlineData(null)]
        public void DeveValidarTrechoComCidadeEDiasInvalidos(string trecho)
        {
            string result = _validadorFormatacaoTrecho.Validar(trecho);

            Assert.True(string.IsNullOrWhiteSpace(result));
        }
    }
}
