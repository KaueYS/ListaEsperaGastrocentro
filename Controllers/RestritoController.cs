using ListaEsperaGastrocentro.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ListaEsperaGastrocentro.Controllers
{
    [UsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
