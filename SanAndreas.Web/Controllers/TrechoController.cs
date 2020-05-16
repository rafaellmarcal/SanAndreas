using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanAndreas.Application.Interfaces;

namespace SanAndreas.Web.Controllers
{
    public class TrechoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Atualizar(
            [FromServices] ITrechoApplicationService _trechoApplicationService,
            IFormFile trechos)
        {
            if (trechos == null)
            {
                TempData["Mensagem"] = "Trechos não informados!";
                return View("Index");
            }

            if (_trechoApplicationService.AtualizarTrechos(trechos))
                TempData["Mensagem"] = "Trechos atualizados com sucesso!";
            else
                TempData["Mensagem"] = "Não foi possível atualizar os trechos!";

            return View("Index");
        }
    }
}