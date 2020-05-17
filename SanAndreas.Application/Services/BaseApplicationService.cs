using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace SanAndreas.Application.Services
{
    public abstract class BaseApplicationService
    {
        protected List<string> ObterLinhasArquivo(IFormFile arquivo)
        {
            List<string> linhasArquivos = new List<string>();

            using (StreamReader reader = new StreamReader(arquivo.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    linhasArquivos.Add(reader.ReadLine());
            }

            return linhasArquivos;
        }
    }
}
