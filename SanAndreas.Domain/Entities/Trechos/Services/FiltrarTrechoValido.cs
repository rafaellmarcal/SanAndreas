using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class FiltrarTrechoValido : IFiltrarTrechoValido
    {
        private readonly IValidadorFormatacaoTrecho _validadorFormatacaoTrecho;

        public FiltrarTrechoValido(
            IValidadorFormatacaoTrecho validadorFormatacaoTrecho)
        {
            _validadorFormatacaoTrecho = validadorFormatacaoTrecho;
        }

        public List<string> Filtrar(List<string> trechos)
        {
            if (trechos == null || !trechos.Any())
                return null;

            List<string> trechosValidos = new List<string>();

            foreach (string trecho in trechos)
            {
                string trechoFormatado = _validadorFormatacaoTrecho.Validar(trecho);

                if (!string.IsNullOrWhiteSpace(trechoFormatado) && !trechosValidos.Contains(trechoFormatado))
                    trechosValidos.Add(trechoFormatado);
            }

            return trechosValidos;
        }
    }
}
