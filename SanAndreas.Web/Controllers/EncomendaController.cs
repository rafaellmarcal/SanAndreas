using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanAndreas.Application.Interfaces;
using System.Net.Mime;

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

            byte[] arquivoRotas = _encomendaApplicationService.CalcularMelhorRota(encomendas);

            if(arquivoRotas == null)
            {
                TempData["Mensagem"] = "Não foi possível calcular as melhores rotas!";
                return View("Index");
            }

            return File(arquivoRotas, MediaTypeNames.Application.Octet, "rotas.txt");
        }
    }
}