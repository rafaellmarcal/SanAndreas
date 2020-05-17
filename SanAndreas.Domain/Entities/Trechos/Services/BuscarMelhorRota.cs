using SanAndreas.Domain.Entities.Base;
using SanAndreas.Domain.Entities.Cidades.Enumerator;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class BuscarMelhorRota : IBuscarMelhorRota
    {
        public string Buscar(string encomenda, List<Trecho> trechosCadastrados)
        {
            string[] informacoesEncomenda = encomenda.Split(Constantes.CaracterDelimitador);

            ECidade cidadeOrigem = (ECidade)Enum.Parse(typeof(ECidade), informacoesEncomenda[0], true);
            ECidade cidadeDestino = (ECidade)Enum.Parse(typeof(ECidade), informacoesEncomenda[1], true);

            Trecho trechoDireto = trechosCadastrados.FirstOrDefault(t => t.CidadeOrigem == cidadeOrigem && t.CidadeDestino == cidadeDestino);

            if (trechoDireto != null)
                return $"{trechoDireto.CidadeOrigem.ToString()} {trechoDireto.CidadeDestino.ToString()} {trechoDireto.QuantidadeDias}";

            List<Trecho> trechosParaDestino = trechosCadastrados.Where(t => t.CidadeOrigem == cidadeOrigem).ToList();

            int maximoRotas = 8;
            List<Trecho> rotasEncontradas = BuscarProximaRota(cidadeOrigem, cidadeDestino, trechosParaDestino, trechosCadastrados, maximoRotas);

            if (rotasEncontradas != null)
            {
                Trecho ultimoRotaEncontrada = rotasEncontradas.Last();

                Trecho proximaRota = trechosParaDestino.FirstOrDefault(t => t.CidadeDestino == ultimoRotaEncontrada.CidadeOrigem);
                rotasEncontradas.Add(proximaRota);

                rotasEncontradas.Reverse();

                int totalDias = rotasEncontradas.Sum(t => t.QuantidadeDias);

                return $"{String.Join(" ", rotasEncontradas.Select(x => String.Join(" ", x.CidadeOrigem.ToString())))} {cidadeDestino.ToString()} {totalDias}";
            }

            return $"{cidadeOrigem.ToString()} {cidadeDestino.ToString()} N/D";
        }

        private List<Trecho> BuscarProximaRota(ECidade cidadeOrigem, ECidade cidadeDestino, List<Trecho> trechosParaDestino, List<Trecho> trechosCadastrados, int maximoRotas)
        {
            List<Trecho> rotasEncontradas = new List<Trecho>();

            if (maximoRotas == 0)
                return null;

            if (!trechosParaDestino.Any(t => t.CidadeDestino == cidadeDestino))
            {
                List<Trecho> proximasRotas = trechosCadastrados
                    .Where(t => t.CidadeDestino != cidadeOrigem && trechosParaDestino.Select(d => d.CidadeDestino).Contains(t.CidadeOrigem))
                    .ToList();

                rotasEncontradas = BuscarProximaRota(cidadeOrigem, cidadeDestino, proximasRotas, trechosCadastrados, maximoRotas - 1);
                if (rotasEncontradas != null)
                {
                    Trecho ultimoRotaEncontrada = rotasEncontradas.Last();

                    if (!proximasRotas.Any(t => t.CidadeOrigem == ultimoRotaEncontrada.CidadeOrigem && t.CidadeDestino == ultimoRotaEncontrada.CidadeDestino))
                    {
                        Trecho proximaRota = proximasRotas.FirstOrDefault(t => t.CidadeDestino == ultimoRotaEncontrada.CidadeOrigem);
                        rotasEncontradas.Add(proximaRota);
                    }

                    return rotasEncontradas;
                }

                return null;
            }

            Trecho trechoDestino = trechosParaDestino.First(t => t.CidadeDestino == cidadeDestino);
            rotasEncontradas.Add(trechoDestino);

            return rotasEncontradas;
        }
    }
}
