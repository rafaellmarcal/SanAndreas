using SanAndreas.Domain.Entities.Base;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class ArmazenadorTrecho : IArmazenadorTrecho
    {
        private static string caminhoArquivo = Constantes.CaminhoBase + "trechos.txt";

        public bool Armazenar(List<string> trechos)
        {
            try
            {
                if (File.Exists(caminhoArquivo))
                    File.Delete(caminhoArquivo);

                using (StreamWriter arquivo = new StreamWriter(caminhoArquivo))
                {
                    foreach (string trecho in trechos)
                    {
                        arquivo.WriteLine(trecho.ToUpper());
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
