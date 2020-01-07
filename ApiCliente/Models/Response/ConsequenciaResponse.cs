using System.Collections.Generic;

namespace ApiCliente.Models.Response
{
    public class ConsequenciaResponse
    {
        public string descricao { get; set; }
        public int idade { get; set; }
        public virtual PessoaResponse Pessoa { get; set; }
        public List<TipoResponse> Tipos { get; set; }
        public int id { get; set; }
    }
}
