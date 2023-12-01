using ListaEsperaGastrocentro.Models;

namespace ListaEsperaGastrocentro.Repositories
{
    public interface IPacienteRepository
    {
        List<Paciente> BuscarTodos(int usuarioId);
        Paciente BuscarPorId(int id);
        Paciente Adicionar(Paciente paciente);
        Paciente Editar(Paciente paciente);
        Paciente Excluir(int id);

    }
}
