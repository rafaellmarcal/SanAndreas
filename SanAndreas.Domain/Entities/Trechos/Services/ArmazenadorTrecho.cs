using SanAndreas.Domain.Entities.Trechos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class ArmazenadorTrecho : IArmazenadorTrecho
    {
        private string nomeArquivo = "trechos.txt";

        public bool Armazenar(List<string> trechos)
        {
            try
            {
                if (File.Exists(nomeArquivo))
                    File.Delete(nomeArquivo);

                using (StreamWriter arquivo = new StreamWriter(nomeArquivo))
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
