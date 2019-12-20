using System;
using System.Collections.Generic;
namespace ApiCliente.Models.Request
{
    public class PessoaRequest
    {
        public string nome { get; set; }
        public int sexo { get; set; } //-- 1-masculino | 2-feminino | 3-ambos
        public Boolean gosto_feminino { get; set; }
        public Boolean gosto_masculino { get; set; }
    }
}
