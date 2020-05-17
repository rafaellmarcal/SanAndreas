using SanAndreas.Domain.Entities.Cidades.Enumerator;
using SanAndreas.Domain.Entities.Trechos;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void DeveRetornarRotaDireta()
        {
            List<Trecho> trechos = GerarListaDeTrechos();
            Tuple<string, string> encomendaformatada = GerarEncomendaFormatada(trechos);

            string result = _buscarMelhorRota.Buscar(encomendaformatada.Item1, trechos);

            Assert.Equal(encomendaformatada.Item2, result);
        }

        [Fact]
        public void DeveRetornarRotaDeEncomendaComMesmaOrigemEDestino()
        {
            List<Trecho> trechos = GerarListaDeTrechosComAMesmaOrigemEDestino();
            Tuple<string, string> encomenda = GerarEncomendaFormatada(trechos);

            string result = _buscarMelhorRota.Buscar(encomenda.Item1, trechos);

            Assert.Equal(encomenda.Item2, result);
        }

        [Theory]
        [InlineData("LS;BC")]
        public void DeveRetornarRotaQuePassaPorTodasCidades(string encomendaFormatada)
        {
            List<Trecho> trechos = GerarTrechosQuePassamPorTodasCidades();

            string result = _buscarMelhorRota.Buscar(encomendaFormatada, trechos);

            string expected = "LS SF LV RC WS BC 5";

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("BC;WS")]
        [InlineData("LS;SF")]
        [InlineData("WS;RC")]
        public void DeveConterInformacaoDeEncomendaSemPossibilidadeDeEntrega(string encomendaFormatada)
        {
            List<Trecho> trechos = GerarListaDeTrechosComAMesmaOrigemEDestino();

            string result = _buscarMelhorRota.Buscar(encomendaFormatada, trechos);

            string expected = "N/D";

            Assert.Contains(expected, result);
        }

        private Tuple<string, string> GerarEncomendaFormatada(List<Trecho> trechos)
        {
            Trecho trecho = trechos.First();

            string encomenda = $"{trecho.CidadeOrigem.ToString()};{trecho.CidadeDestino.ToString()}";
            string rota = $"{trecho.CidadeOrigem.ToString()} {trecho.CidadeDestino.ToString()} {trecho.QuantidadeDias}";

            return new Tuple<string, string>(encomenda, rota);
        }

        private List<Trecho> GerarListaDeTrechos()
        {
            return new List<Trecho>()
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
        }

        private List<Trecho> GerarListaDeTrechosComAMesmaOrigemEDestino()
        {
            return new List<Trecho>()
            {
                new Trecho()
                {
                    CidadeOrigem = ECidade.LS,
                    CidadeDestino = ECidade.LS,
                    QuantidadeDias = 1
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.WS,
                    CidadeDestino = ECidade.WS,
                    QuantidadeDias = 3
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.BC,
                    CidadeDestino = ECidade.BC,
                    QuantidadeDias = 5
                }
            };
        }

        private List<Trecho> GerarTrechosQuePassamPorTodasCidades()
        {
            return new List<Trecho>()
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
                    CidadeDestino = ECidade.LV,
                    QuantidadeDias = 1
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.LV,
                    CidadeDestino = ECidade.RC,
                    QuantidadeDias = 1
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.RC,
                    CidadeDestino = ECidade.WS,
                    QuantidadeDias = 1
                },
                new Trecho()
                {
                    CidadeOrigem = ECidade.WS,
                    CidadeDestino = ECidade.BC,
                    QuantidadeDias = 1
                }
            };
        }
    }
}
