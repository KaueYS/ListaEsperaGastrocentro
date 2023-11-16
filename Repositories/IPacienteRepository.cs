using ListaEsperaGastrocentro.Models;

namespace ListaEsperaGastrocentro.Repositories
{
    public interface IPacienteRepository
    {
        List<Paciente> GetPaciente();
        Paciente GetById(int id);
        void Add(Paciente paciente);
        void Update(Paciente paciente);
        void Delete(int id);

    }
}
