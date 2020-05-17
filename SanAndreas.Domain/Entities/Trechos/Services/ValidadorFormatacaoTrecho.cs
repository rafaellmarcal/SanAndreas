using SanAndreas.Domain.Entities.Base;
using SanAndreas.Domain.Entities.Cidades.Enumerator;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class ValidadorFormatacaoTrecho : IValidadorFormatacaoTrecho
    {
        private static string caracterDelimitador = Constantes.CaracterDelimitador;

        public string Validar(string trecho)
        {
            trecho = Regex.Replace(trecho, @"\s+", caracterDelimitador);
            string[] informacaoTrecho = trecho.Split(caracterDelimitador);

            if (informacaoTrecho.Length != 3)
                return string.Empty;

            if (!Enum.TryParse(informacaoTrecho[0], out ECidade cidadeOrigem))
                return string.Empty;

            if (!Enum.TryParse(informacaoTrecho[1], out ECidade cidadeDestino))
                return string.Empty;

            if (!Int32.TryParse(informacaoTrecho[2], out int quantidadeDias))
                return string.Empty;

            return $"{cidadeOrigem}{caracterDelimitador}{cidadeDestino}{caracterDelimitador}{quantidadeDias}";
        }
    }
}
