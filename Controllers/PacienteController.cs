using ListaEsperaGastrocentro.Filters;
using ListaEsperaGastrocentro.Models;
using ListaEsperaGastrocentro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ListaEsperaGastrocentro.Controllers
{
    [UsuarioLogado]
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public IActionResult Index()
        {
            var buscar = _pacienteRepository.BuscarTodos();
            return View(buscar);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _pacienteRepository.Adicionar(paciente);
                return RedirectToAction("Index");

            }
            return View(paciente);

        }

        public IActionResult Editar(int id)
        {
            Paciente paciente = _pacienteRepository.BuscarPorId(id);
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Editar(Paciente paciente)
        {
            _pacienteRepository.Editar(paciente);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            _pacienteRepository.Excluir(id);

            return RedirectToAction("Index");
        }


        public IActionResult ConfirmarExcluir(int id)
        {
            var paciente = _pacienteRepository.BuscarPorId(id);

            return View(paciente);

        }

    }
}
