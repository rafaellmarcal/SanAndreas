using SanAndreas.Domain.Entities.Base;
using SanAndreas.Domain.Entities.Cidades.Enumerator;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System;
using System.Collections.Generic;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class ConverterTrecho : IConverterTrecho
    {
        public List<Trecho> Converter(List<string> trechosCadastrados)
        {
            List<Trecho> trechos = new List<Trecho>();

            foreach (string trecho in trechosCadastrados)
            {
                string[] informacoesTrecho = trecho.Split(Constantes.CaracterDelimitador);
                trechos.Add(new Trecho()
                {
                    CidadeOrigem = (ECidade)Enum.Parse(typeof(ECidade), informacoesTrecho[0], true),
                    CidadeDestino = (ECidade)Enum.Parse(typeof(ECidade), informacoesTrecho[1], true),
                    QuantidadeDias = Int32.Parse(informacoesTrecho[2])
                });
            }

            return trechos;
        }
    }
}
