using ListaEsperaGastrocentro.Enums;
using System.ComponentModel;

namespace ListaEsperaGastrocentro.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        
        public string Senha { get; set; }
        public PerfilEnum Perfil { get; set; }

    }
}
