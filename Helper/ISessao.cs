using ListaEsperaGastrocentro.Models;

namespace ListaEsperaGastrocentro.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(Usuario usuario);

        void RemoverSessaoUsuario();

        Usuario BuscarSessaoUsuario();

    }
}
