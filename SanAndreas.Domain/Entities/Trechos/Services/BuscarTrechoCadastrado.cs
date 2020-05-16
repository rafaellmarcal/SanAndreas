using SanAndreas.Domain.Entities.Trechos.Interfaces.Services;
using System;
using System.IO;

namespace SanAndreas.Domain.Entities.Trechos.Services
{
    public class BuscarTrechoCadastrado : IBuscarTrechoCadastrado
    {
        private string temp = "";

        public BuscarTrechoCadastrado()
        {
        }

        public string[] Buscar()
        {
            try
            {
                string[] trechosDisponiveis = File.ReadAllLines(temp);
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
