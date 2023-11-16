using ListaEsperaGastrocentro.Context;
using ListaEsperaGastrocentro.Models;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace ListaEsperaGastrocentro.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;

        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Paciente> GetPaciente()
        {
            return _context.PACIENTES.ToList();
        }

        public Paciente GetById(int id)
        {
            var paciente = _context.PACIENTES.FirstOrDefault(x=>x.Id == id);
            return paciente;
            
        }

        public void Add(Paciente paciente)
        {
            _context.Add(paciente);
            _context.SaveChanges();
        }
        public void Update(Paciente paciente)
        {
            _context.Update(paciente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var paciente = _context.PACIENTES.FirstOrDefault(x => x.Id == id);
            _context.Remove(paciente);
            _context.SaveChanges();
            
        }
    }
}
