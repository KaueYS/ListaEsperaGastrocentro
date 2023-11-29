namespace ListaEsperaGastrocentro.Helper
{
    public interface IEmail
    {
        bool MandarEmail(string email, string assunto, string mensagem);
        
    }
}
