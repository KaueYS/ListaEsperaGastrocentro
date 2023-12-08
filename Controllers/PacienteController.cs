using ListaEsperaGastrocentro.Filters;
using ListaEsperaGastrocentro.Helper;
using ListaEsperaGastrocentro.Models;
using ListaEsperaGastrocentro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ListaEsperaGastrocentro.Controllers
{
    [UsuarioLogado]
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ISessao _sessao;

        public PacienteController(IPacienteRepository pacienteRepository, ISessao sessao)
        {
            _pacienteRepository = pacienteRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoUsuario();
            var paciente = _pacienteRepository.BuscarTodos(usuarioLogado.Id);
            return View(paciente);
        }

        public IActionResult Criar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Paciente paciente)
        {

            Usuario usuarioLogado = _sessao.BuscarSessaoUsuario();
            paciente.UsuarioId = usuarioLogado.Id;
            
            _pacienteRepository.Adicionar(paciente);
            return RedirectToAction("Index");


            //return View(paciente);

        }

        public IActionResult Editar(int id)
        {
            Paciente paciente = _pacienteRepository.BuscarPorId(id);
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Editar(Paciente paciente)
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoUsuario();
            paciente.UsuarioId = usuarioLogado.Id;

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
