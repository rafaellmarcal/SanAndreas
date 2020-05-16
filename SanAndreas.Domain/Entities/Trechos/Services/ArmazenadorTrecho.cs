using SanAndreas.Domain.Entities.Trechos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class ArmazenadorTrecho : IArmazenadorTrecho
    {
        private static string caminhoArquivo = "D:\\Take\\SanAndreas\\trechos.txt";

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
                        arquivo.WriteLine(trecho);
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
