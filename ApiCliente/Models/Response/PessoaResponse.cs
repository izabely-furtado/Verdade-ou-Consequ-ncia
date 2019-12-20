using System;

namespace ApiCliente.Models.Response
{
    public class PessoaResponse
    {
        public string nome { get; set; }
        public int sexo { get; set; } //-- 1-masculino | 2-feminino | 3-ambos
        public Boolean gosto_feminino { get; set; }
        public Boolean gosto_masculino { get; set; }
    }
}
