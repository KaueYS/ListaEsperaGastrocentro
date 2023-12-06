using ListaEsperaGastrocentro.Context;
using ListaEsperaGastrocentro.Interfaces;
using ListaEsperaGastrocentro.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaEsperaGastrocentro.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly AppDbContext _context;

        public UsuarioServico(AppDbContext context)
        {
            _context = context;
        }

        public async Task <List<Usuario>> BuscarUsuarios()
        {
            return await _context.USUARIOS.ToListAsync();
        }
    }
}
