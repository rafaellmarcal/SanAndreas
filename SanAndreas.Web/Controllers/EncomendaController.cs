using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanAndreas.Application.Interfaces;

namespace SanAndreas.Web.Controllers
{
    public class EncomendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(
            [FromServices] IEncomendaApplicationService _encomendaApplicationService,
            IFormFile encomendas)
        {
            if (encomendas == null)
            {
                TempData["Mensagem"] = "Encomendas não informadas!";
                return View("Index");
            }

            byte[] rotasCalculadas = _encomendaApplicationService.CalcularMelhorRota(encomendas);
            return File(rotasCalculadas, System.Net.Mime.MediaTypeNames.Application.Octet, "rotas.txt");
        }
    }
}