using Microsoft.AspNetCore.Http;
using SanAndreas.Application.Interfaces;

namespace SanAndreas.Application.Services
{
    public class EncomendaApplicationService : IEncomendaApplicationService
    {
        public EncomendaApplicationService()
        {

        }

        public byte[] CalcularMelhorRota(IFormFile encomendas)
        {
            throw new System.NotImplementedException();
        }
    }
}
