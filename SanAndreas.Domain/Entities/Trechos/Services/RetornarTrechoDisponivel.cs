using SanAndreas.Domain.Entities.Trechos.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class RetornarTrechoDisponivel : IRetornarTrechoDisponivel
    {
        private readonly IValidadorFormatacaoTrecho _validadorFormatacaoTrecho;

        public RetornarTrechoDisponivel(
            IValidadorFormatacaoTrecho validadorTrecho)
        {
            _validadorFormatacaoTrecho = validadorTrecho;
        }

        public List<string> Filtrar(List<string> trechos)
        {
            if (trechos == null || !trechos.Any())
                return null;

            List<string> trechosDisponiveis = new List<string>();

            foreach (string trecho in trechos)
            {
                string trechoFormatado = _validadorFormatacaoTrecho.Validar(trecho);

                if (!string.IsNullOrWhiteSpace(trechoFormatado) && !trechosDisponiveis.Contains(trechoFormatado))
                    trechosDisponiveis.Add(trechoFormatado);
            }

            return trechosDisponiveis;
        }
    }
}
