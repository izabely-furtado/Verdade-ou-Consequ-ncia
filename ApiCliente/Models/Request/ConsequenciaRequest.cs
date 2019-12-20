namespace ApiCliente.Models.Request
{
    public class ConsequenciaRequest
    {
        public string descricao { get; set; }
        public int idade { get; set; }
        public PessoaRequest Pessoa { get; set; }
    }
}
