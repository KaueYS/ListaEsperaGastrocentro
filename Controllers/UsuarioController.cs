using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListaEsperaGastrocentro.Context;
using ListaEsperaGastrocentro.Models;
using ListaEsperaGastrocentro.Interfaces;

namespace ListaEsperaGastrocentro.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioController(AppDbContext context, IUsuarioServico usuarioServico)
        {
            _context = context;
            _usuarioServico = usuarioServico;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioServico.BuscarUsuarios();
            return View(usuarios);
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.USUARIOS == null)
            {
                return NotFound();
            }

            var usuario = await _context.USUARIOS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Login,Email,Senha,Perfil")] Usuario usuario)
        {
            await _usuarioServico.CriarUsuario(usuario);
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.USUARIOS == null)
            {
                return NotFound();
            }

            var usuario = await _context.USUARIOS.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Login,Email,Senha,Perfil")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.USUARIOS == null)
            {
                return NotFound();
            }

            var usuario = await _context.USUARIOS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.USUARIOS == null)
            {
                return Problem("Entity set 'AppDbContext.USUARIOS'  is null.");
            }
            var usuario = await _context.USUARIOS.FindAsync(id);
            if (usuario != null)
            {
                _context.USUARIOS.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return (_context.USUARIOS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
