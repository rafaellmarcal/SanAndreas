using SanAndreas.Domain.Entities.Cidades.Enumerator;
using SanAndreas.Domain.Entities.Trechos;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Services;
using System.Collections.Generic;
using Xunit;

namespace SanAndreas.Tests.SanAndreas.Domain
{
    public class BuscarMelhorRotaTest
    {
        private IBuscarMelhorRota _buscarMelhorRota;

        public BuscarMelhorRotaTest()
        {
            _buscarMelhorRota = new BuscarMelhorRota();
        }

        [Fact]
        public void DeveRetornarAMelhorRota()
        {
            string encomenda = "SF;WS";
            List<Trecho> trechos = GerarListaDeTrechos();

            string result = _buscarMelhorRota.Buscar(encomenda, trechos);
            
            Assert.Equal("WS SF LV BC 5", result);
        }

        //[Fact]
        //public void NaoDeveRetornarRotaParaTrechoNaoCa

        private List<Trecho> GerarListaDeTrechos()
        {
            List<Trecho> trechos = new List<Trecho>()
            {
                new Trecho()
                {
                    CidadeOrigem = ECidade.LS,
                    CidadeDestino = ECidade.SF,
                    QuantidadeDias = 1
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.SF,
                    CidadeDestino = ECidade.LS,
                    QuantidadeDias = 2
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.LS,
                    CidadeDestino = ECidade.LV,
                    QuantidadeDias = 1
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.LV,
                    CidadeDestino = ECidade.LS,
                    QuantidadeDias = 1
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.SF,
                    CidadeDestino = ECidade.LV,
                    QuantidadeDias = 2
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.LV,
                    CidadeDestino = ECidade.SF,
                    QuantidadeDias = 2
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.LS,
                    CidadeDestino = ECidade.RC,
                    QuantidadeDias = 1
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.RC,
                    CidadeDestino = ECidade.LS,
                    QuantidadeDias = 2
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.SF,
                    CidadeDestino = ECidade.WS,
                    QuantidadeDias = 1
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.WS,
                    CidadeDestino = ECidade.SF,
                    QuantidadeDias = 2
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.LV,
                    CidadeDestino = ECidade.BC,
                    QuantidadeDias = 1
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.BC,
                    CidadeDestino = ECidade.LV,
                    QuantidadeDias = 1
                },
            };

            return trechos;
        }
    }
}
