using SanAndreas.Domain.Entities.Base;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class BuscarTrechoCadastrado : IBuscarTrechoCadastrado
    {
        private static string caminhoArquivo = Constantes.CaminhoBase + "trechos.txt";

        public List<string> Buscar()
        {
            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    List<string> trechosDisponiveis = File.ReadAllLines(caminhoArquivo).ToList();
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
