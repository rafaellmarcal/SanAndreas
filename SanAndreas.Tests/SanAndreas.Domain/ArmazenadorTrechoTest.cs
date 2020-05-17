using SanAndreas.Domain.Entities.Base;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Services;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SanAndreas.Tests.SanAndreas.Domain
{
    public class ArmazenadorTrechoTest
    {
        private IArmazenadorTrecho _armazenadorTrecho;

        public ArmazenadorTrechoTest()
        {
            _armazenadorTrecho = new ArmazenadorTrecho();
        }

        [Fact]
        public void DeveArmazenarTrechos()
        {
            List<string> trechos = GerarTrechosFormatadosEValidos();

            bool result = _armazenadorTrecho.Armazenar(trechos);

            Assert.True(result);
        }

        [Fact]
        public void DeveVerificarSeArquivoFoiCriado()
        {
            string expected = "trechos.txt";
            List<string> trechos = GerarTrechosFormatadosEValidos();

            _armazenadorTrecho.Armazenar(trechos);

            bool result = File.Exists(expected);

            Assert.True(result);
        }

        private List<string> GerarTrechosFormatadosEValidos()
        {
            return new List<string>()
            {
                "WS;SF;2",
                "RC;BC;2",
                "LS;SF;3",
            };
        }
    }
}
