using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SanAndreas.Web.Controllers
{
    public class EncomendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}