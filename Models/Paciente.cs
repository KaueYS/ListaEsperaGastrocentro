namespace ListaEsperaGastrocentro.Models
{
    public class Paciente
    {
        public int Id { get; set; }


        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Finalizado { get; set; } = false;
    }
}
