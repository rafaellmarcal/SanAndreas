using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class BuscarTrechoCadastrado : IBuscarTrechoCadastrado
    {
        private string nomeArquivo = "trechos.txt";

        public List<string> Buscar()
        {
            try
            {
                if (File.Exists(nomeArquivo))
                {
                    List<string> trechosDisponiveis = File.ReadAllLines(nomeArquivo).ToList();
                    return trechosDisponiveis;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
