using Microsoft.AspNetCore.Http;

namespace SanAndreas.Application.Interfaces
{
    public interface ITrechoApplicationService
    {
        bool AtualizarTrechos(IFormFile trechos);
    }
}
