using System.ComponentModel.DataAnnotations;

namespace ListaEsperaGastrocentro.Models
{
    public class Paciente
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Email Obrigatorio")]
        [EmailAddress(ErrorMessage = "Digite um email valido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Telefone Obrigatorio")]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "Data do cadastro obrigatorio")]
        public DateTime DataCadastro { get; set; }
        

        public string? Observacao { get; set; }
                
       
        public bool Finalizado { get; set; } = false;

        public Usuario Usuario { get; set; }

        public int? UsuarioId { get; set; }

    }
}
