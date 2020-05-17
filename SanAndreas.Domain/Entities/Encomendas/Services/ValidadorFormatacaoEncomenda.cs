using SanAndreas.Domain.Entities.Base;
using SanAndreas.Domain.Entities.Cidades.Enumerator;
using SanAndreas.Domain.Entities.Encomendas.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class ValidadorFormatacaoEncomenda : IValidadorFormatacaoEncomenda
    {
        private static string caracterDelimitador = Constantes.CaracterDelimitador;

        public string Validar(string encomenda)
        {
            encomenda = Regex.Replace(encomenda.ToUpper(), @"\s+", caracterDelimitador);
            string[] informacaoEncomenda = encomenda.Split(caracterDelimitador);

            if (informacaoEncomenda.Length != 2)
                return string.Empty;

            if (!Enum.TryParse(informacaoEncomenda[0], out ECidade cidadeOrigem))
                return string.Empty;

            if (!Enum.TryParse(informacaoEncomenda[1], out ECidade cidadeDestino))
                return string.Empty;

            return $"{cidadeOrigem}{caracterDelimitador}{cidadeDestino}";
        }
    }
}
