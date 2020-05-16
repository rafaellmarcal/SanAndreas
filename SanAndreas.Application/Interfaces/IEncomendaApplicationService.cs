using Microsoft.AspNetCore.Http;

namespace SanAndreas.Application.Interfaces
{
    public interface IEncomendaApplicationService
    {
        byte[] CalcularMelhorRota(IFormFile encomendas);
    }
}
