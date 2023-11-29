using ListaEsperaGastrocentro.Enums;
using ListaEsperaGastrocentro.Helper;
using System.ComponentModel;

namespace ListaEsperaGastrocentro.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        
        public string Senha { get; set; }
        public PerfilEnum Perfil { get; set; }

        public virtual List<PacienteModel> Pacientes { get; set; }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();

            return novaSenha;
        }


        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();  
        }
        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }
    }
}
