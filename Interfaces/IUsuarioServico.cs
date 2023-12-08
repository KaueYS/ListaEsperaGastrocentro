using ListaEsperaGastrocentro.Models;

namespace ListaEsperaGastrocentro.Interfaces
{
    public interface IUsuarioServico
    {
        Task <List<Usuario>> BuscarUsuarios();
        //Task <Usuario> ConsultarUsuario();
        Task <Usuario> CriarUsuario(Usuario usuario);
    }
}
