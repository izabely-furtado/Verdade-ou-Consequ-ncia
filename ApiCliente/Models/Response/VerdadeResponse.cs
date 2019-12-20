using System;

namespace ApiCliente.Models.Response
{
    public class VerdadeResponse
    {
        public string descricao { get; set; }
        public int idade { get; set; }
        public PessoaResponse Pessoa { get; set; }
        public SequenciaResponse Sequencia { get; set; }
    }
}
