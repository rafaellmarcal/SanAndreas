using SanAndreas.Domain.Entities.Base;
using SanAndreas.Domain.Entities.Encomendas.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SanAndreas.Domain.Entities.Encomendas.Services
{
    public class GerarSaidaEncomenda : IGerarSaidaEncomenda
    {
        public byte[] GerarSaida(List<string> rotasCalculadasEncomendas)
        {
            if (rotasCalculadasEncomendas == null || !rotasCalculadasEncomendas.Any())
                return null;

            string nomeArquivo = $"{Constantes.CaminhoBase}{DateTime.Now.ToFileTime()}rotas.txt";

            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                foreach (string rotaCalculada in rotasCalculadasEncomendas)
                    writer.WriteLine(rotaCalculada);
            }

            MemoryStream memory = new MemoryStream();
            using (FileStream stream = new FileStream(nomeArquivo, FileMode.Open))
            {
                stream.CopyTo(memory);
            }

            memory.Position = 0;

            File.Delete(nomeArquivo);

            return memory.ToArray();
        }
    }
}
