using ListaEsperaGastrocentro.Context;
using ListaEsperaGastrocentro.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public List<Paciente> BuscarTodos()
        {
            return _context.PACIENTES.ToList();
        }

        public Paciente BuscarPorId(int id)
        {
            var paciente = _context.PACIENTES.FirstOrDefault(x => x.Id == id);
            if (paciente != null)
            {
                return paciente;
            }
            throw new Exception("Id nao cadastrado");

        }

        public Paciente Adicionar(Paciente paciente)
        {
            _context.Add(paciente);
            _context.SaveChanges();
            return paciente;
        }

        
        public Paciente Editar(Paciente paciente)
        {
            Paciente pacienteId = new Paciente();
            pacienteId = _context.PACIENTES.FirstOrDefault(x => x.Id == paciente.Id);
            if (pacienteId != null)
            {
                pacienteId.Nome = paciente.Nome;
                pacienteId.Email = paciente.Email;
                pacienteId.Telefone = paciente.Telefone;
                pacienteId.Observacao = paciente.Observacao;
                pacienteId.Finalizado = paciente.Finalizado;
                pacienteId.DataCadastro = paciente.DataCadastro;

                _context.PACIENTES.Update(pacienteId);
                _context.SaveChanges();
                return pacienteId;
            }
            throw new Exception("nao foi possivel atualizar o cadastrado");
        }

        public Paciente Excluir(int id)
        {
            var pacienteExcluir = _context.PACIENTES.FirstOrDefault(x => x.Id == id);
            if (pacienteExcluir != null)
            {
                _context.Remove(pacienteExcluir); 
                _context.SaveChanges();
                return pacienteExcluir;
            }
            else
            {
                throw new Exception("Nao foi possivel apagar");
            }
        }
    }
}
