using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiCliente.Models.Request
{
    public class VerdadeRequest
    {
        public string descricao { get; set; }
        public int idade { get; set; }
        public PessoaRequest Pessoa { get; set; }
        public SequenciaRequest Sequencia { get; set; }
    }
}
