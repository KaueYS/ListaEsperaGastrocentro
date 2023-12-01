using ListaEsperaGastrocentro.Context;
using ListaEsperaGastrocentro.Helper;
using ListaEsperaGastrocentro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaEsperaGastrocentro.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISessao _sessao;
        public LoginController(AppDbContext context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entrar = _context.USUARIOS.FirstOrDefault(x => x.Login == loginModel.Login && x.Senha == loginModel.Senha);
                    if (entrar != null)
                    {
                        _sessao.CriarSessaoUsuario(entrar);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = $"LOGIN ou SENHA inválido(s), tente novamente!";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }
    }

}
