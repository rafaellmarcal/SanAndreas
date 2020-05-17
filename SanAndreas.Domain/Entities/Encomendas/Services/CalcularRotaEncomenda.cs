using SanAndreas.Domain.Entities.Encomendas.Interfaces;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class CalcularRotaEncomenda : ICalcularRotaEncomenda
    {
        private readonly IBuscarMelhorRota _buscarMelhorRota;
        private readonly IConverterTrecho _converterTrecho;
        private readonly IValidadorFormatacaoEncomenda _validadorFormatacaoEncomenda;

        public CalcularRotaEncomenda(
            IBuscarMelhorRota buscarMelhorRota,
            IConverterTrecho converterTrecho,
            IValidadorFormatacaoEncomenda validadorFormatacaoEncomenda)
        {
            _buscarMelhorRota = buscarMelhorRota;
            _converterTrecho = converterTrecho;
            _validadorFormatacaoEncomenda = validadorFormatacaoEncomenda;
        }

        public List<string> Calcular(List<string> encomendas, List<string> trechosCadastrados)
        {
            List<string> rotasCalculadas = new List<string>();

            if (encomendas == null || !encomendas.Any() ||
                trechosCadastrados == null || !trechosCadastrados.Any())
                return null;

            List<Trecho> trechos = _converterTrecho.Converter(trechosCadastrados);

            foreach (string encomenda in encomendas)
            {
                string encomendaFormatada = _validadorFormatacaoEncomenda.Validar(encomenda);

                rotasCalculadas.Add(_buscarMelhorRota.Buscar(encomendaFormatada, trechos));
            }

            return rotasCalculadas;
        }
    }
}
